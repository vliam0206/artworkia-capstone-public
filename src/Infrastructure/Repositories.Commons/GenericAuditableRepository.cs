using Application.Commons;
using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Commons;

public class GenericAuditableRepository<TEntity> : GenericCreationRepository<TEntity>
                where TEntity : BaseEntity, ICreation, IModification, ISoftDelete
{
    private readonly IClaimService _claimService;
    public GenericAuditableRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
        _claimService = claimService;
    }

    public override void Update(TEntity entity)
    {
        entity.LastModificatedOn = DateTime.UtcNow.ToLocalTime();
        entity.LastModificatedBy = _claimService.GetCurrentUserId;
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public override void UpdateRange(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.LastModificatedOn = DateTime.UtcNow.ToLocalTime();
            entity.LastModificatedBy = _claimService.GetCurrentUserId;
        }
        _dbSet.UpdateRange(entities);
    }

    public override void SoftDelete(TEntity entity)
    {
        entity.DeletedOn = DateTime.UtcNow.ToLocalTime();
        entity.DeletedBy = _claimService.GetCurrentUserId;
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public override async Task<List<TEntity>> GetAllUndeletedAsync()
    {
        return await _dbSet.Where(x => x.DeletedOn == null).OrderByDescending(x => x.CreatedOn).ToListAsync();
    }
}
