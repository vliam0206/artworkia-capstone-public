using Application.Services;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ArtworksController : ControllerBase
{
    private readonly IArtworkService _artworkService;
    private readonly IMapper _mapper;

    public ArtworksController(IArtworkService artworkService, IMapper mapper)
    {
        _artworkService = artworkService;
        _mapper = mapper;
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

    [HttpPost]
    public async Task<IActionResult> AddArtwork([FromBody] ArtworkModel artworkModel)
    {
        Artwork artwork;
        if (artworkModel == null)
            return BadRequest();
        try
        {
            artwork = _mapper.Map<Artwork>(artworkModel);
            await _artworkService.AddArtworkAsync(artwork);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpDelete("{artworkId}")]
    public async Task<IActionResult> DeleteArtwork(Guid artworkId)
    {
        await _artworkService.DeleteArtworkAsync(artworkId);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArtwork([FromBody] ArtworkModel artworkModel)
    {
        Artwork artwork;
        if (artworkModel == null)
            return BadRequest();
        try
        {
            artwork = _mapper.Map<Artwork>(artworkModel);
            await _artworkService.AddArtworkAsync(artwork);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        await _artworkService.UpdateArtworkAsync(artwork);
        return Ok();
    }
}
