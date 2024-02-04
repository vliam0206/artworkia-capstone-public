using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
namespace Application.Services;
public class ArtworkService : IArtworkService
{
    private static readonly string PARENT_FOLDER = "Artwork";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly ITagDetailService _tagDetailService;
    private readonly ICategoryArtworkDetailService _categoryArtworkDetailService;
    private readonly IFirebaseService _firebaseService;
    private readonly IMapper _mapper;
    public ArtworkService(
        IUnitOfWork unitOfWork,
        IImageService imageService,
        ITagDetailService tagDetailService,
        ICategoryArtworkDetailService catworkDetailService,
        IFirebaseService firebaseService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _tagDetailService = tagDetailService;
        _categoryArtworkDetailService = catworkDetailService;
        _firebaseService = firebaseService;
        _mapper = mapper;
    }

    public async Task<PagedList<ArtworkPreviewVM>> GetAllArtworksAsync(ArtworkCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllArtworksAsync(
            criteria.categoryId, criteria.status, criteria.keyword, criteria.sortColumn,
            criteria.sortOrder, criteria.PageNumber, criteria.PageSize);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);
        return listArtworkPreviewVM;
    }

    public async Task<PagedList<ArtworkModerationVM>> GetAllArtworksForModerationAsync(ArtworkCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllArtworksAsync(
            criteria.categoryId, criteria.status, criteria.keyword, criteria.sortColumn,
            criteria.sortOrder, criteria.PageNumber, criteria.PageSize);
        var listArtworkModerationVM = _mapper.Map<PagedList<ArtworkModerationVM>>(listArtwork);
        return listArtworkModerationVM;
    }

    public async Task<PagedList<ArtworkPreviewVM>> GetAllArtworksByAccountIdAsync(Guid accountId, ArtworkCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllArtworksByAccountIdAsync(
            accountId, criteria.status, criteria.keyword, criteria.sortColumn, criteria.sortOrder, 
            criteria.PageNumber, criteria.PageSize);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);
        return listArtworkPreviewVM;
    }

    public async Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId)
    {
        var artwork = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(artworkId);
        if (artwork == null)
            throw new NullReferenceException("Artwork not found!");

        if (artwork.DeletedOn != null)
            throw new Exception("Artwork deleted!");
        var artworkVM = _mapper.Map<ArtworkVM>(artwork);
        return artworkVM;
    }

    public async Task<ArtworkVM> AddArtworkAsync(ArtworkModel artworkModel)
    {
        var newArtwork = _mapper.Map<Artwork>(artworkModel);
        string newThumbnailName = newArtwork.Id + "_t";
        string folderName = $"{PARENT_FOLDER}/Thumbnail";
        string extension = System.IO.Path.GetExtension(artworkModel.Thumbnail.FileName);
        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(artworkModel.Thumbnail, newThumbnailName, folderName);
        if (url == null)
            throw new Exception("Cannot upload thumbnail image to firebase!");
        newArtwork.Thumbnail = url;
        newArtwork.ThumbnailName = newThumbnailName + extension;
        newArtwork.Status = StateEnum.Accepted;
        // them artwork 
        await _unitOfWork.ArtworkRepository.AddAsync(newArtwork);
        await _unitOfWork.SaveChangesAsync();

        // them tag 
        TagListArtworkModel tagListArtworkModel = new TagListArtworkModel()
        {
            ArtworkId = newArtwork.Id,
            TagList = artworkModel.Tags
        };
        await _tagDetailService.AddTagListArtworkAsync(tagListArtworkModel, false);

        // them cate
        CategoryListArtworkModel categoryList = new CategoryListArtworkModel()
        {
            ArtworkId = newArtwork.Id,
            CategoryList = artworkModel.Categories
        };
        await _categoryArtworkDetailService.AddCategoryListArtworkAsync(categoryList, false);

        // them hinh anh
        MultiImageModel multiImageModel = new MultiImageModel()
        {
            ArtworkId = newArtwork.Id,
            Images = artworkModel.ImageFiles
        };
        await _imageService.AddRangeImageAsync(multiImageModel, false);

        bool flagPrice = false;
        // them asset
        if (artworkModel.AssetFiles != null)
        {
            var uploadAssetsTask = new List<Task>();
            foreach (var singleAsset in artworkModel.AssetFiles.Select((file, index) => (file, index)))
            {
                if (flagPrice == false && singleAsset.file.Price > 0)
                {
                    flagPrice = true;
                }
                Guid artworkId = newArtwork.Id;
                string newAssetName = artworkId + "_a" + singleAsset.index;
                string assetFolderName = $"{PARENT_FOLDER}/Asset";
                string imageExtension = Path.GetExtension(singleAsset.file.File.FileName); 

                // upload asset len firebase, lay url
                uploadAssetsTask.Add(Task.Run(async () =>
                {
                    var url = await _firebaseService.UploadFileToFirebaseStorage(singleAsset.file.File, newAssetName, assetFolderName);
                    if (url == null)
                        throw new Exception("Cannot upload asset to firebase!");

                    Asset newAsset = new()
                    {
                        ArtworkId = artworkId,
                        Location = url,
                        AssetName = newAssetName + imageExtension,
                        AssetTitle = singleAsset.file.AssetTitle,
                        Description = singleAsset.file.Description,
                        Price = singleAsset.file.Price,
                    };
                    await _unitOfWork.AssetRepository.AddAsync(newAsset);
                }));
            }
            await Task.WhenAll(uploadAssetsTask);
        }

        if (flagPrice) 
            newArtwork.Status = StateEnum.Waiting;
        else 
            newArtwork.Status = StateEnum.Accepted;

        await _unitOfWork.SaveChangesAsync();
        var result = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(newArtwork.Id);
        return _mapper.Map<ArtworkVM>(result);
    }

    public async Task DeleteArtworkAsync(Guid artworkId)
    {
        var result = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (result == null)
            throw new Exception("Cannot found artwork!");
        _unitOfWork.ArtworkRepository.SoftDelete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateArtworkAsync(Guid artworkId, ArtworkEM artworkEM)
    {
        var oldArtwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (oldArtwork == null)
            throw new Exception("Cannot found artwork!");

        oldArtwork.Title = artworkEM.Title;
        oldArtwork.Description = artworkEM.Description;
        oldArtwork.Privacy = artworkEM.Privacy;

        _unitOfWork.ArtworkRepository.Update(oldArtwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateArtworkStatusAsync(Guid artworkId, StateEnum status)
    {
        var oldArtwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (oldArtwork == null)
            throw new Exception("Cannot found artwork!");

        oldArtwork.Status = status;
        await _unitOfWork.SaveChangesAsync();
    }
}
