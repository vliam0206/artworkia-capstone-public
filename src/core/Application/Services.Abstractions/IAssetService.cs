using Application.Models;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IAssetService
{
    Task<Asset?> GetAssetByIdAsync(Guid assetId);
    Task<List<Asset>> GetAllAssetsAsync();
    Task<List<Asset>> GetAllAssetsOfArtworkAsync(Guid artworkId);
    Task AddAssetAsync(AssetModel assetModel);
    Task AddRangeAssetAsync(MultiAssetModel multiAssetModel);
    Task UpdateAssetAsync(Asset asset);
    Task DeleteAssetAsync(Guid assetId);

}
