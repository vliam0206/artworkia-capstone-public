using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Repositories.Abstractions;

namespace Application.Services;

public class CategoryArtworkDetailService : ICategoryArtworkDetailService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryArtworkDetailService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddCategoryArtworkAsync(CategoryArtworkModel categoryArtworkModel)
    {
        bool IsCategoryExist = await _unitOfWork.CategoryRepository.IsExisted(categoryArtworkModel.CategoryId);
        if (!IsCategoryExist)
        {
            throw new NullReferenceException("Category does not exist");
        }
        CategoryArtworkDetail categoryArtworkDetail = _mapper.Map<CategoryArtworkDetail>(categoryArtworkModel);
        await _unitOfWork.CategoryArtworkDetailRepository.AddCategoryArtworkAsync(categoryArtworkDetail);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddCategoryListArtworkAsync(CategoryListArtworkModel categoryListArtworkModel)
    {
        var artwork = _unitOfWork.ArtworkRepository.GetByIdAsync(categoryListArtworkModel.ArtworkId);
        if (artwork == null)
        {
            throw new Exception("Artwork not found");
        }

        var categoryList = categoryListArtworkModel.CategoryList;
        foreach (var category in categoryList)
        {
            CategoryArtworkModel categoryArtworkModel = new CategoryArtworkModel
            {
                ArtworkId = categoryListArtworkModel.ArtworkId,
                CategoryId = category
            };
            await AddCategoryArtworkAsync(categoryArtworkModel);
        }
    }

    public Task DeleteCategoryArtworkAsync(Guid categoryArtworkId)
    {
        throw new NotImplementedException();
    }
}
