﻿using Domain.Entitites;

namespace Domain.Repositories.Abstractions;

public interface IAssetRepository : IGenericRepository<Asset>
{
    Task<Asset?> GetAssetAndItsCreatorAsync(Guid assetId);
}
