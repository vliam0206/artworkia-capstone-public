﻿using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface IAssetService
{
    Task<Asset?> GetAssetByIdAsync(Guid assetId);
    Task<List<Asset>> GetAllAssetsAsync();
    Task AddAssetAsync(Asset asset);
    Task AddRangeAssetAsync(Asset asset);
    Task UpdateAssetAsync(Asset asset);
    Task DeleteAssetAsync(Guid assetId);

}
