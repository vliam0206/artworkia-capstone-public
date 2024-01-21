using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using WebApi.ViewModels;
using WebApi.ViewModels.Commons;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _categoryService.GetAllCategoriesAsync();
        return Ok(result);
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoryById(Guid categoryId)
    {
        try
        {
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);
            return Ok(result);
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }   
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddCategory(CategoryModel categoryModel)
    {
        try
        {
            var category = await _categoryService.AddCategoryAsync(categoryModel);
            return CreatedAtAction(nameof(GetCategoryById), 
                new { categoryId = category.Id }, category);
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpPut("{categoryId}")]
    [Authorize]
    public async Task<IActionResult> UpdateCategory(Guid categoryId, CategoryEM categoryEM)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(categoryId, categoryEM);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message   
            });
          } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpDelete("{categoryId}")]
    [Authorize]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        try
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess= false,
                ErrorMessage = ex.Message
            });
        } catch 
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Error when deleting! If you are deleting the main category, " +
                "please make sure to delete all subcategories first."
            });
        }
    }
}
