using Domain.Entities.Commons;
using System.Linq.Expressions;

namespace Domain.Repositories.Abstractions;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> IsExisted(Guid id);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(List<TEntity> entities);
    void Delete(TEntity entity);
    void SoftDelete(TEntity entity);
    Task<TEntity?> GetSingleByConditionAsync(Expression<Func<TEntity, bool>> query);
    Task<List<TEntity>> GetListByConditionAsync(Expression<Func<TEntity, bool>> query);
}
