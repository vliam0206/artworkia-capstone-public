using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(AppDBContext dBContext) : base(dBContext)
    {
    }

    public async Task<Tag?> GetTagByNameAsync(string tagName)
    {
        return await _dbContext.Tags.FirstOrDefaultAsync(x => x.TagName == tagName);
    }
}
