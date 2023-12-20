using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.ViewModels;

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
        await _tagService.DeleteTagAsync(tagId);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddTag([FromBody] TagModel tagModel)
    {
        Tag tag;
        if (tagModel == null)
            return BadRequest();
        if (tagModel.TagName.IsNullOrEmpty())
            return BadRequest("Tag name must not be empty");

        try
        {
            tag = _mapper.Map<Tag>(tagModel);
            await _tagService.AddTagAsync(tag);
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }
}
