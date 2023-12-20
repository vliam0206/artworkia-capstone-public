using Domain.Entitites;

namespace Application.Services.Abstractions;
public interface ICategoryService
{
    Task<Category?> GetCategoryByIdAsync(Guid categoryId);
    Task<List<Category>> GetAllCategoriesAsync();
    Task DeleteCategoryAsync(Guid categoryId);
    Task UpdateCategoryAsync(Category category);
    Task AddCategoryAsync(Category category);
}
