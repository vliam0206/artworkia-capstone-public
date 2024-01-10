using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IAssetService
{
    Task<AssetVM?> GetAssetByIdAsync(Guid assetId);
    Task<List<AssetVM>> GetAllAssetsAsync();
    Task<List<AssetVM>> GetAllAssetsOfArtworkAsync(Guid artworkId);
    Task<AssetVM> AddAssetAsync(AssetModel assetModel);
    Task AddRangeAssetAsync(MultiAssetModel multiAssetModel);
    Task UpdateAssetAsync(Guid assetId, AssetEM assetEM);
    Task DeleteAssetAsync(Guid assetId);

}
