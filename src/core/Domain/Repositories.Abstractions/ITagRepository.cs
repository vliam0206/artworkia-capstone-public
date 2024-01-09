using Domain.Entitites;

namespace Domain.Repositories.Abstractions;
public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetTagByNameAsync(string tagName);
}
