using Application.Models;
using Application.Services.Abstractions;
using Application.Services.Firebase;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class AssetService : IAssetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;   
    private readonly IFirebaseService _firebaseService;

    public AssetService(IUnitOfWork unitOfWork, IMapper mapper, IFirebaseService firebaseService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _firebaseService = firebaseService;
    }

    public async Task<List<AssetVM>> GetAllAssetsAsync()
    {
        var listAsset = await _unitOfWork.AssetRepository.GetAllUndeletedAsync();
        var listAssetVM = _mapper.Map<List<AssetVM>>(listAsset);
        return listAssetVM;
    }

    public async Task<AssetVM?> GetAssetByIdAsync(Guid assetId)
    {
        var asset = await _unitOfWork.AssetRepository.GetByIdAsync(assetId); 
        if (asset == null)
            throw new NullReferenceException("Asset does not exist!");
        if (asset.DeletedOn != null)
            throw new Exception("Asset already deleted!");
        var assetVM = _mapper.Map<AssetVM>(asset);
        return assetVM;
    }

    // lay so thu tu lon nhat cua asset trong artwork
    private async Task<int> GetLatestOrderOfAssetInArtwork(Guid artworkId)
    {
        var allAssetsOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        return allAssetsOfArtwork.Count;
    }

    public async Task<AssetVM> AddAssetAsync(AssetModel assetModel)
    {
        // kiem tra artwork co ton tai khong
        var artwork = await _unitOfWork.ArtworkRepository.GetByIdAsync(assetModel.ArtworkId);
        if (artwork == null)
            throw new NullReferenceException("Artwork that contains this image does not exist!");
        if (artwork.DeletedOn != null)
            throw new Exception("Artwork deleted!");

        // lay stt cua hinh anh, dat ten lai hinh anh
        int latestOrder = await GetLatestOrderOfAssetInArtwork(assetModel.ArtworkId);
        string newAssetName = assetModel.ArtworkId + "_a" + latestOrder;
        string imageExtension = Path.GetExtension(assetModel.File.FileName); // lay duoi file (.zip, .rar, ...)


        // upload asset len firebase, lay url
        var url = await _firebaseService.UploadFileToFirebaseStorage(assetModel.File, newAssetName, "Asset");
        if (url == null)
            throw new Exception("Cannot upload asset to firebase!");

        // map assetModel sang asset
        Asset newAsset = _mapper.Map<Asset>(assetModel);
        newAsset.Location = url;
        newAsset.AssetName = newAssetName + imageExtension;
        newAsset.Order = latestOrder;
        await _unitOfWork.AssetRepository.AddAsync(newAsset);
        await _unitOfWork.SaveChangesAsync();

        var assetVM = _mapper.Map<AssetVM>(newAsset);
        return assetVM;
    }

    public async Task AddRangeAssetAsync(MultiAssetModel multiAssetModel)
    {
        // kiem tra artwork co ton tai khong
        bool IsArtworkExisted = await _unitOfWork.ArtworkRepository.IsExisted(multiAssetModel.ArtworkId);
        if (!IsArtworkExisted)
            throw new NullReferenceException("Artwork that contains this image does not exist!");
        var allAssetsOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == multiAssetModel.ArtworkId);
        if (allAssetsOfArtwork.Count > 0)
            throw new Exception("Artwork already has assets!");

        int index = 0;
        foreach (var singleAsset in multiAssetModel.Assets)
        {
            string newAssetName = multiAssetModel.ArtworkId + "_a" + index;
            string imageExtension = Path.GetExtension(singleAsset.File.FileName); // lay duoi file (.zip, .rar, ...)

            // upload asset len firebase, lay url
            var url = await _firebaseService.UploadFileToFirebaseStorage(singleAsset.File, newAssetName, "Asset");
            if (url == null)
                throw new Exception("Cannot upload asset to firebase!");

            Asset newAsset = new Asset()
            {
                ArtworkId = multiAssetModel.ArtworkId,
                AssetTitle = singleAsset.AssetTitle,
                Description = singleAsset.Description,
                Price = singleAsset.Price,
                Location = url,
                AssetName = newAssetName + imageExtension,
                Order = index
            };
            await _unitOfWork.AssetRepository.AddAsync(newAsset);
            index++;
        }
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAssetAsync(Guid assetId)
    {
        var result = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (result == null)
            throw new Exception("Cannot found asset!");
        _unitOfWork.AssetRepository.SoftDelete(result);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAssetAsync(Guid assetId, AssetEM assetEM)
    {
        var oldAsset = await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
        if (oldAsset == null)
            throw new NullReferenceException("Asset does not exist!");
        oldAsset.AssetTitle = assetEM.AssetTitle;
        oldAsset.Description = assetEM.Description;
        oldAsset.Price = assetEM.Price;

        _unitOfWork.AssetRepository.Update(oldAsset);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<AssetVM>> GetAllAssetsOfArtworkAsync(Guid artworkId)
    {
        var listAssetOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        if (listAssetOfArtwork == null)
            throw new NullReferenceException("This artwork does not have any asset!");
        var listAssetVMOfArtwork = _mapper.Map<List<AssetVM>>(listAssetOfArtwork);
        return listAssetVMOfArtwork;
    }
}
