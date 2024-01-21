using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public TagsController(ITagService tagService, IMapper mapper)
    {
        _tagService = tagService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var result = await _tagService.GetAllTagsAsync();
        return Ok(result);
    }

    /// <summary>
    /// Tìm kiếm tag có tên chứa keyword
    /// </summary>
    /// <param name="keyword">từ khoá tìm kiếm</param>
    /// <returns>trả về danh sách tag, tối đa 20 tag</returns>
    [HttpGet("search/{keyword}")]
    public async Task<IActionResult> SearchTagsByName(string keyword)
    {
        try
        {
            var result = await _tagService.SearchTagsByNameAsync(keyword);
            return Ok(result);
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpGet("{tagId}")]
    public async Task<IActionResult> GetTagById(Guid tagId)
    {
        try
        {
            var result = await _tagService.GetTagByIdAsync(tagId);
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

    [HttpDelete("{tagId}")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> DeleteTag(Guid tagId)
    {
        try
        {
            await _tagService.DeleteTagAsync(tagId);
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

    [HttpPost]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> AddTag([FromBody] TagModel tagModel)
    {
        tagModel.TagName = tagModel.TagName.Trim();
        if (!_tagService.IsTagValid(tagModel.TagName))
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = $"Tag name '{tagModel.TagName}' is invalid (only contains uppercase, lowercase, digits, space, 2-30 characters)"
            });
        try
        {
            TagVM tagVM = await _tagService.AddTagAsync(tagModel);
            return CreatedAtAction(nameof(GetTagById), new { tagId = tagVM.Id }, tagVM);
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            }); ;
        }
    }

    [HttpPut("{tagId}")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> EditTag(Guid tagId, [FromBody] TagModel tagModel)
    {
        tagModel.TagName = tagModel.TagName.Trim();
        if (!_tagService.IsTagValid(tagModel.TagName))
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = $"Tag name '{tagModel.TagName}' is invalid (only contains uppercase, lowercase, digits, space, 2-30 characters)."
            });

        try
        {
            await _tagService.EditTagAsync(tagId, tagModel);
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
}
