using Application.Filters;
using Application.Models;
using Domain.Entities.Commons;
using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IAssetService
{
    Task<AssetVM?> GetAssetByIdAsync(Guid assetId);
    Task<string?> GetDownloadUriAssetAsync(Guid assetId);
    Task<IPagedList<AssetVM>> GetAllAssetsAsync(AssetCriteria criteria);
    Task<IPagedList<AssetVM>> GetAssetsOfAccountAsync(Guid accountId, AssetCriteria criteria);
    Task<List<AssetVM>> GetAllAssetsOfArtworkAsync(Guid artworkId);
    Task<AssetVM> AddAssetAsync(AssetModel assetModel);
    Task AddRangeAssetAsync(MultiAssetModel multiAssetModel, bool isSaveChanges = true);
    Task UpdateAssetAsync(Guid assetId, AssetEM assetEM);
    Task DeleteAssetAsync(Guid assetId);

}
