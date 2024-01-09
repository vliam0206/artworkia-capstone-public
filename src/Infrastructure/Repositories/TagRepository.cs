using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    private readonly AppDBContext _dbContext;
    public TagRepository(AppDBContext dBContext) : base(dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<Tag?> GetTagByNameAsync(string tagName)
    {
        return await _dbContext.Tags.FirstOrDefaultAsync(x => x.TagName == tagName);
    }
}
