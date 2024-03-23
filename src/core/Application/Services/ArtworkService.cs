using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;
using Domain.Repositories.Abstractions;
using System.Security.Principal;
namespace Application.Services;
public class ArtworkService : IArtworkService
{
    private static readonly string PARENT_FOLDER = "Artwork";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly ITagDetailService _tagDetailService;
    private readonly ICategoryArtworkDetailService _categoryArtworkDetailService;
    private readonly IFirebaseService _firebaseService;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;
    public ArtworkService(
        IUnitOfWork unitOfWork,
        IImageService imageService,
        ITagDetailService tagDetailService,
        ICategoryArtworkDetailService catworkDetailService,
        IFirebaseService firebaseService,
        IClaimService claimService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _tagDetailService = tagDetailService;
        _categoryArtworkDetailService = catworkDetailService;
        _firebaseService = firebaseService;
        _claimService = claimService;
        _mapper = mapper;
    }

    public async Task<PagedList<ArtworkPreviewVM>> GetAllArtworksAsync(ArtworkCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllArtworksAsync(
            criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize,
            null, criteria.CategoryId, criteria.TagId);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);
        return listArtworkPreviewVM;
    }

    public async Task<PagedList<ArtworkModerationVM>> GetAllArtworksForModerationAsync(ArtworkModerationCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllArtworksForModerationAsync(
            criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize,
            null, criteria.CategoryId, criteria.TagId, criteria.State, criteria.Privacy);
        var listArtworkModerationVM = _mapper.Map<PagedList<ArtworkModerationVM>>(listArtwork);
        return listArtworkModerationVM;
    }

    public async Task<PagedList<ArtworkPreviewVM>> GetAllArtworksByAccountIdAsync(Guid accountId, ArtworkModerationCriteria criteria)
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllArtworksAsync(
            criteria.Keyword, criteria.SortColumn,
            criteria.SortOrder, criteria.PageNumber, criteria.PageSize,
            accountId, criteria.CategoryId, criteria.TagId, criteria.State, criteria.Privacy);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);
        return listArtworkPreviewVM;
    }
    public async Task<PagedList<ArtworkPreviewVM>> GetArtworksOfFollowingsAsync(PagedCriteria criteria)
    {
        Guid followerId = _claimService.GetCurrentUserId ?? default;
        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksOfFollowingsAsync(
            followerId, criteria.PageNumber, criteria.PageSize);
        var listArtworkPreviewVM = _mapper.Map<PagedList<ArtworkPreviewVM>>(listArtwork);
        return listArtworkPreviewVM;
    }

    public async Task<List<ImageDuplicationVM>> GetArtworksDuplicateAsync(Guid artworkId)
    {
        var isExisted = await _unitOfWork.ArtworkRepository.IsExistedAsync(artworkId);
        if (!isExisted)
            throw new NullReferenceException("Cannot found artwork!");
        var listArtwork = await _unitOfWork.ArtworkRepository.GetArtworksDuplicateAsync(artworkId);
        var listArtworkVM = _mapper.Map<List<ImageDuplicationVM>>(listArtwork);
        return listArtworkVM;
    }

    public async Task<ArtworkVM?> GetArtworkByIdAsync(Guid artworkId)
    {
        Guid? accountId = _claimService.GetCurrentUserId;

        var artwork = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(artworkId);
        if (artwork == null)
            throw new NullReferenceException("Artwork not found.");
        if (artwork.DeletedOn != null)
            throw new Exception("Artwork deleted.");

        var artworkVM = _mapper.Map<ArtworkVM>(artwork);

        // check if user is logged in
        if (accountId != null)
        {
            // check if account is blocking or blocked
            if (await _unitOfWork.BlockRepository.IsBlockedOrBlockingAsync(accountId.Value, artworkVM.CreatedBy!.Value))
            {
                throw new Exception("Can not view artwork because of blocking!");
            }
            // check if user liked this artwork
            var isLiked = await _unitOfWork.LikeRepository.GetByIdAsync(accountId.Value, artworkId);
            artworkVM.IsLiked = isLiked != null;
        }

        // increase view count
        artwork.ViewCount++;
        _unitOfWork.ArtworkRepository.Update(artwork);
        await _unitOfWork.SaveChangesAsync();

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
        // them artwork 
        await _unitOfWork.ArtworkRepository.AddAsync(newArtwork);
        //await _unitOfWork.SaveChangesAsync();

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
            newArtwork.State = StateEnum.Waiting;
        else 
            newArtwork.State = StateEnum.Accepted;

        await _unitOfWork.SaveChangesAsync();
        var result = await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(newArtwork.Id);
        return _mapper.Map<ArtworkVM>(result);
    }

    public async Task DeleteArtworkAsync(Guid artworkId)
    {
        // check if artwork exist
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork == null)
            throw new Exception("Cannot found artwork!");

        // check authorized
        if (_claimService.GetCurrentRole.Equals(RoleEnum.CommonUser.ToString()) &&
            artwork.CreatedBy != _claimService.GetCurrentUserId)
        {
            throw new UnauthorizedAccessException("You are not allow to access this function.");
        }   
        _unitOfWork.ArtworkRepository.Delete(artwork);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SoftDeleteArtworkAsync(Guid artworkId)
    {
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork == null)
            throw new Exception("Cannot found artwork!");

        // check authorized
        if (_claimService.GetCurrentRole.Equals(RoleEnum.CommonUser.ToString()) &&
            artwork.CreatedBy != _claimService.GetCurrentUserId)
        {
            throw new UnauthorizedAccessException("You are not allow to access this function.");
        }
        _unitOfWork.ArtworkRepository.SoftDelete(artwork);
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

    public async Task UpdateArtworkStateAsync(Guid artworkId, ArtworkStateEM model)
    {
        var oldArtwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (oldArtwork == null)
            throw new Exception("Cannot found artwork!");
        if (oldArtwork.State != StateEnum.Waiting)
            throw new Exception($"Report already resolve! (current state is {oldArtwork.State})");
        oldArtwork.State = model.State;
        oldArtwork.Note = model.Note;
        _unitOfWork.ArtworkRepository.Update(oldArtwork);
        await _unitOfWork.SaveChangesAsync();
    }

}
