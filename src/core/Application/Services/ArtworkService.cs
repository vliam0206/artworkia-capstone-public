using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class ArtworkService : IArtworkService
{
    private static readonly string PARENT_FOLDER = "Artwork";
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly IAssetService _assetService;
    private readonly ITagDetailService _tagDetailService;
    private readonly ICategoryArtworkDetailService _categoryArtworkDetailService;
    private readonly IFirebaseService _firebaseService;
    private readonly IMapper _mapper;
    public ArtworkService(
        IUnitOfWork unitOfWork,
        IImageService imageService,
        IAssetService assetService,
        ITagDetailService tagDetailService,
        ICategoryArtworkDetailService catworkDetailService,
        IFirebaseService firebaseService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _assetService = assetService;
        _tagDetailService = tagDetailService;
        _categoryArtworkDetailService = catworkDetailService;
        _firebaseService = firebaseService;
        _mapper = mapper;
    }

    public async Task<List<ArtworkPreviewVM>> GetAllArtworksAsync()
    {
        var listArtwork = await _unitOfWork.ArtworkRepository.GetAllUndeletedAsync();
        var listArtowkPreviewVM = _mapper.Map<List<ArtworkPreviewVM>>(listArtwork);
        return listArtowkPreviewVM;
    }


    public async Task<List<ArtworkPreviewVM>> GetArtworksBySearchAsync(SearchArtworkCriteria searchArtworkCriteria)
    {
        var result = await _unitOfWork.ArtworkRepository.GetAllUndeletedAsync();
        if (searchArtworkCriteria.Key != null)
        {
            result = result.Where(x => x.Title.ToLower().Contains(searchArtworkCriteria.Key.ToLower())).ToList();
        }

        if (searchArtworkCriteria.Sort != null)
        {
            if (searchArtworkCriteria.Sort == "createdOn")
            {
                if (searchArtworkCriteria.Order == "asc")
                {
                    result = result.OrderBy(x => x.CreatedOn).ToList();
                } else
                {
                    result = result.OrderByDescending(x => x.CreatedOn).ToList();
                }
            }
        }

        return _mapper.Map<List<ArtworkPreviewVM>>(result);
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
        string folderName = $"{PARENT_FOLDER}/{newArtwork.Id}/Thumbnail";
        string extension = System.IO.Path.GetExtension(artworkModel.Thumbnail.FileName);
        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(artworkModel.Thumbnail, newThumbnailName, folderName);
        if (url == null)
            throw new Exception("Cannot upload thumbnail image to firebase!");
        newArtwork.Thumbnail = url;
        newArtwork.ThumbnailName = newThumbnailName + extension;

        // them artwork 
        await _unitOfWork.ArtworkRepository.AddAsync(newArtwork);
        await _unitOfWork.SaveChangesAsync();

        // them tag 
        TagListArtworkModel tagListArtworkModel = new TagListArtworkModel()
        {
            ArtworkId = newArtwork.Id,
            TagList = artworkModel.Tags
        };
        await _tagDetailService.AddTagListArtworkAsync(tagListArtworkModel);

        // them cate
        CategoryListArtworkModel categoryList = new CategoryListArtworkModel()
        {
            ArtworkId = newArtwork.Id,
            CategoryList = artworkModel.Categories
        };
        await _categoryArtworkDetailService.AddCategoryListArtworkAsync(categoryList);

        // them hinh anh 
        MultiImageModel multiImageModel = new MultiImageModel()
        {
            ArtworkId = newArtwork.Id,
            Images = artworkModel.ImageFiles
        };
        await _imageService.AddRangeImageAsync(multiImageModel);

        // them asset
        if (artworkModel.AssetFiles != null)
        {
            MultiAssetModel multiAssetModel = new MultiAssetModel()
            {
                ArtworkId = newArtwork.Id,
                Assets = artworkModel.AssetFiles
            };
            await _assetService.AddRangeAssetAsync(multiAssetModel);
        }

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
}
