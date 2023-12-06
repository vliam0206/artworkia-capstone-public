using Application.Commons;
using Application.Services.Abstractions;
using Domain.Entities.Commons;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Commons;

public class GenericAuditableRepository<TEntity> : GenericCreationRepository<TEntity>
                where TEntity : BaseEntity, ICreation, IModification, ISoftDelete
{
    private readonly AppDBContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    private readonly IClaimService _claimService;
    public GenericAuditableRepository(AppDBContext dBContext, IClaimService claimService) : base(dBContext, claimService)
    {
        _dbContext = dBContext;
        _dbSet = _dbContext.Set<TEntity>();
        _claimService = claimService;
    }

    public override void Update(TEntity entity)
    {
        entity.LastModificatedBy = _claimService.GetCurrentUserId;
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public override void UpdateRange(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.LastModificatedBy = _claimService.GetCurrentUserId;
        }
        _dbSet.UpdateRange(entities);
    }

    public override void SoftDelete(TEntity entity)
    {
        entity.DeletedOn = DateTime.UtcNow;
        entity.DeletedBy = _claimService.GetCurrentUserId;
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}
