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
        return await _dbContext.Tags.FirstOrDefaultAsync(x => x.TagName.ToLower().Equals(tagName.ToLower()));
    }

    public async Task<List<Tag>> SearchTagsByNameAsync(string keyword)
    {
        return await _dbContext.Tags
            .Where(x => EF.Functions.Like(x.TagName, $"%{keyword}%"))
            .Take(20)
            .ToListAsync();
    }
}
