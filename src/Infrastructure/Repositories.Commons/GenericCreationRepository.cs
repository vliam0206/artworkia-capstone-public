using Application.Commons;
using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Commons;

public class GenericCreationRepository<TEntity> : GenericRepository<TEntity>
                                        where TEntity : BaseEntity, ICreation
{
    private readonly IClaimService _claimService;
    public GenericCreationRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext)
    {
        _claimService = claimService;
    }

    public override async Task AddAsync(TEntity entity)
    {
        entity.CreatedOn = DateTime.UtcNow.ToLocalTime();
        entity.CreatedBy = _claimService.GetCurrentUserId;
        await _dbSet.AddAsync(entity);
    }

    public override async Task AddRangeAsync(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedOn = DateTime.UtcNow.ToLocalTime();
            entity.CreatedBy = _claimService.GetCurrentUserId;
        }
        await _dbSet.AddRangeAsync(entities);
    }

    public override async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.OrderByDescending(x => x.CreatedOn)
                    .ToListAsync();
    }
}
