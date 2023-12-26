using Application.Commons;
using Domain.Entities.Commons;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Commons;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly AppDBContext _dbContext;
    public GenericRepository(AppDBContext dBContext)
    {
        _dbContext = dBContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    public virtual async Task AddAsync(TEntity entity)
        => await _dbSet.AddAsync(entity);

    public virtual async Task AddRangeAsync(List<TEntity> entities)
        => await _dbSet.AddRangeAsync(entities);

    public virtual void Delete(TEntity entity)
        => _dbSet.Remove(entity);
    public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public virtual void SoftDelete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual void Update(TEntity entity)
        => _dbContext.Entry(entity).State = EntityState.Modified;

    public virtual void UpdateRange(List<TEntity> entities)
        => _dbSet.UpdateRange(entities);

    public async Task<TEntity?> GetSingleByConditionAsync(Expression<Func<TEntity, bool>> query)
    {
        return await _dbSet.SingleOrDefaultAsync(query);
    }
    public async Task<List<TEntity>> GetListByConditionAsync(Expression<Func<TEntity, bool>> query)
    {
        return await _dbSet.Where(query).ToListAsync();
    }
}
