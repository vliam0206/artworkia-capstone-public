﻿using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    private AppDBContext _dbContext;
    private IClaimService _claimService;

    public AssetRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext)
    {
        _dbContext = dBContext;
        _claimService = claimService;
    }

    public override void SoftDelete(Asset asset)
    {
        asset.DeletedOn = DateTime.UtcNow.ToLocalTime();
        asset.DeletedBy = _claimService.GetCurrentUserId;
        _dbContext.Entry(asset).State = EntityState.Modified;
    }

    public override void Update(Asset entity)
    {
        base.Update(entity);
        entity.LastModificatedBy = _claimService.GetCurrentUserId;
    }

    public override async Task<List<Asset>> GetAllUndeletedAsync()
    {
        return await _dbContext.Assets.Where(a => a.DeletedOn == null).ToListAsync();
    }
}
