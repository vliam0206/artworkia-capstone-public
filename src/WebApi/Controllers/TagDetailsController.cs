using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;
namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagDetailsController : ControllerBase
{
    private readonly ITagDetailService _tagDetailService;

    public TagDetailsController(ITagDetailService tagDetailService)
    {
        _tagDetailService = tagDetailService;
    }

    [HttpGet("artwork/{artworkId}")]
    public async Task<IActionResult> GetAllTagDetailsOfArtwork(Guid artworkId)
    {
        var result = await _tagDetailService.GetTagListOfArtworkAsync(artworkId);
        return Ok(result);
    }
}
