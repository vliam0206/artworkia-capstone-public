using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ArtworksController : ControllerBase
{
    private readonly IArtworkService _artworkService;

    public ArtworksController(IArtworkService artworkService)
    {
        _artworkService = artworkService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArtworks()
    {
        var result = await _artworkService.GetAllArtworksAsync();
        return Ok(result);
    }   

    [HttpGet("{artworkId}")]
    public async Task<IActionResult> GetArtworkById(Guid artworkId)
    {
        var result = await _artworkService.GetArtworkByIdAsync(artworkId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    //[HttpPost]  
    //public async Task<IActionResult> AddArtwork([FromBody] Artwork artwork)
    //{
    //    await _artworkService.AddArtworkAsync(artwork);
    //    return Ok();
    //}

    [HttpDelete("{artworkId}")]
    public async Task<IActionResult> DeleteArtwork(Guid artworkId)
    {
        await _artworkService.DeleteArtworkAsync(artworkId);
        return Ok();
    }

    //[HttpPut]
    //public async Task<IActionResult> UpdateArtwork([FromBody] Artwork artwork)
    //{
    //    await _artworkService.UpdateArtworkAsync(artwork);
    //    return Ok();
    //}
}
