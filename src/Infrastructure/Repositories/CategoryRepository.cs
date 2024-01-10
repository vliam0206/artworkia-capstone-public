using Domain.Entitites;
using Domain.Repositories.Abstractions;
using Infrastructure.Database;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly AppDBContext _dBContext;
    public CategoryRepository(AppDBContext dBContext) : base(dBContext)
    {
        _dBContext = dBContext;
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
    {
        return await _dBContext.Categories.Include(x => x.Parent)
            .FirstOrDefaultAsync(x => x.Id == categoryId);
    }
}
