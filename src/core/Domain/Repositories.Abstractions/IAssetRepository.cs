using Domain.Entities.Commons;
using Domain.Entitites;
using Domain.Enums;

namespace Domain.Repositories.Abstractions;

public interface IAssetRepository : IGenericRepository<Asset>
{
    Task<Asset?> GetAssetAndItsCreatorAsync(Guid assetId);
    Task<IPagedList<Asset>> GetAllAssetsAsync(
        Guid? accountId, int? minPrice, int? maxPrice, string? keyword, 
        string? sortColumn, string? sortOrder, int page, int pageSize);
}
