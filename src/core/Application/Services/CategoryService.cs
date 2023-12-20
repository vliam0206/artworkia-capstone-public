using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
       return await _unitOfWork.CategoryRepository.GetAllAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
    {
        return await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);  
    }
    public async Task AddCategoryAsync(Category category)
    {
        await _unitOfWork.CategoryRepository.AddAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid categoryId)
    {
        var result = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
        if (result == null)
            throw new Exception("Cannot found category!");
        _unitOfWork.CategoryRepository.Delete(result);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var result = await _unitOfWork.CategoryRepository.GetByIdAsync(category.Id);
        if (result == null) 
            throw new Exception("Cannot found category!");
        _unitOfWork.CategoryRepository.Update(category);
    }
}
