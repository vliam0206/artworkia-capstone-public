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

    public async Task<List<Asset>> GetAllAssetsAsync()
    {
        return await _unitOfWork.AssetRepository.GetAllAsync();
    }

    public async Task<Asset?> GetAssetByIdAsync(Guid assetId)
    {
        return await _unitOfWork.AssetRepository.GetByIdAsync(assetId);
    }

    // lay so thu tu lon nhat cua asset trong artwork
    private async Task<int> GetLatestOrderOfAssetInArtwork(Guid artworkId)
    {
        var allAssetsOfArtwork = await _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        return allAssetsOfArtwork.Count;
    }

    public async Task AddAssetAsync(AssetModel assetModel)
    {
        // kiem tra artwork co ton tai khong
        bool IsArtworkExisted = await _unitOfWork.ArtworkRepository.IsExisted(assetModel.ArtworkId);
        if (!IsArtworkExisted)
            throw new NullReferenceException("Artwork that contains this image does not exist!");

        // lay stt cua hinh anh, dat ten lai hinh anh
        int latestOrder = await GetLatestOrderOfAssetInArtwork(assetModel.ArtworkId);
        string newAssetName = assetModel.ArtworkId + "_a" + latestOrder;
        string imageExtension = Path.GetExtension(assetModel.File.FileName); // lay duoi file (.zip, .rar, ...)


        // upload asset len firebase, lay url
        var url = await _firebaseService.UploadFileToFirebaseStorage(assetModel.File, newAssetName, "Asset");
        if (url == null)
            throw new Exception("Cannot upload asset to firebase!");
        Asset newAsset = _mapper.Map<Asset>(assetModel);
        newAsset.Location = url;
        newAsset.AssetName = newAssetName + imageExtension;
        newAsset.Order = latestOrder;
        await _unitOfWork.AssetRepository.AddAsync(newAsset);
        await _unitOfWork.SaveChangesAsync();
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

    public async Task UpdateAssetAsync(Asset asset)
    {
        _unitOfWork.AssetRepository.Update(asset);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<List<Asset>> GetAllAssetsOfArtworkAsync(Guid artworkId)
    {
        var result = _unitOfWork.AssetRepository.GetListByConditionAsync(x => x.ArtworkId == artworkId);
        return result;
    }
}
