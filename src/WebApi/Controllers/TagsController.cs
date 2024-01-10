using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
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
        var resultModel = _mapper.Map<List<TagVM>>(result);
        return Ok(resultModel);
    }

    [HttpGet("{tagId}")]
    public async Task<IActionResult> GetTagById(Guid tagId)
    {
        var result = await _tagService.GetTagByIdAsync(tagId);
        if (result == null)
            return NotFound();
        var resultModel = _mapper.Map<TagVM>(result);
        return Ok(resultModel);
    }

    [HttpDelete("{tagId}")]
    public async Task<IActionResult> DeleteTag(Guid tagId)
    {
        try
        {
            await _tagService.DeleteTagAsync(tagId);
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
        return Ok(new ApiResponse
        {
            IsSuccess = true
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddTag([FromBody] TagModel tagModel)
    {
        tagModel.TagName = tagModel.TagName.Trim();
        if (!IsTagValid(tagModel.TagName))
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = $"Tag name '{tagModel.TagName}' is invalid (only contains uppercase, lowercase, digits, underscrore, 1-30 characters)"
            });
        try
        {
            Tag tag = _mapper.Map<Tag>(tagModel);
            await _tagService.AddTagAsync(tag);
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            }); ;
        }
        return Ok(tagModel);
    }

    private bool IsTagValid(string tagName)
    {
        // Kiểm tra xem tag có chứa chữ cái, số, và dấu gạch dưới không
        if (!Regex.IsMatch(tagName, "^[a-zA-Z0-9_]+$"))
        {
            return false;
        }
        return true;
    }
}
