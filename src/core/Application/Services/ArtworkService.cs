using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class ArtworkService : IArtworkService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;
    private readonly IAssetService _assetService;
    private readonly ITagDetailService _tagDetailService;
    private readonly IFirebaseService _firebaseService;
    private readonly IMapper _mapper;
    public ArtworkService(
        IUnitOfWork unitOfWork,
        IImageService imageService,
        IAssetService assetService,
        ITagDetailService tagDetailService,
        IFirebaseService firebaseService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _assetService = assetService;
        _tagDetailService = tagDetailService;
        _firebaseService = firebaseService;
        _mapper = mapper;
    }

    public async Task<List<Artwork>> GetAllArtworksAsync()
    {
        return await _unitOfWork.ArtworkRepository.GetAllAsync();
    }

    public Task<List<ArtworkSearchVM>> GetArtworksBySearchAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Artwork?> GetArtworkByIdAsync(Guid artworkId)
    {
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (artwork != null)
        {
            await _unitOfWork.ArtworkRepository.GetArtworkDetailByIdAsync(artworkId);
        }

        return artwork;
    }
    public async Task<Guid> AddArtworkAsync(ArtworkModel artworkModel)
    {
        var newArtwork = _mapper.Map<Artwork>(artworkModel);
        string newThumbnailName = newArtwork.Id + "_t";
        string extension = System.IO.Path.GetExtension(artworkModel.Thumbnail.FileName);
        // them thumbnail image vao firebase
        var url = await _firebaseService.UploadFileToFirebaseStorage(artworkModel.Thumbnail, newThumbnailName, "ThumbnailArtwork");
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
        return newArtwork.Id;
    }

    public async Task DeleteArtworkAsync(Guid artworkId)
    {
        var result = await _unitOfWork.ArtworkRepository.GetByIdAsync(artworkId);
        if (result == null)
            throw new Exception("Cannot found artwork!");
        _unitOfWork.ArtworkRepository.SoftDelete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateArtworkAsync(Artwork artwork)
    {
        var result = await _unitOfWork.ArtworkRepository.GetByIdAsync(artwork.Id);
        if (result == null)
            throw new Exception("Cannot found artwork!");
        artwork.CreatedOn = result.CreatedOn;
        _unitOfWork.ArtworkRepository.Update(artwork);
        await _unitOfWork.SaveChangesAsync();
    }
}
