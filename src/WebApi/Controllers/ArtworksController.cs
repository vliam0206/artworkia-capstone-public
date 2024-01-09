using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Utils;
using WebApi.ViewModels;
using WebApi.ViewModels.Commons;

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
        var resultModel = _mapper.Map<List<ArtworkVM>>(result);
        return Ok(new ApiResponse
        {
            IsSuccess = true,
            Result = resultModel
        });
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetArtworksBySearch([FromQuery] ItemFilterCriteria filterCriteria)
    {
        //var result = await _artworkService.GetArtworksBySearchAsync();
        var filteredItems = FetchItemsFromDataSource(filterCriteria);

        return Ok(new ApiResponse
        {
            IsSuccess = true,
            Result = filteredItems
        });
    }

    private IEnumerable<ArtworkSearchVM> FetchItemsFromDataSource(ItemFilterCriteria filterCriteria)
    {
        // Implement logic to fetch items from your data source
        // based on the filtering criteria (e.g., using Entity Framework, etc.)
        // Example:
        //var query = dbContext.Items.AsQueryable();

        //if (filterCriteria.PriceGte.HasValue)
        //{
        //    query = query.Where(item => item.Price >= filterCriteria.PriceGte.Value);
        //}

        //if (filterCriteria.PriceLte.HasValue)
        //{
        //    query = query.Where(item => item.Price <= filterCriteria.PriceLte.Value);
        //}

        //return query.ToList();
        return new List<ArtworkSearchVM>();
    }

    public class ItemFilterCriteria
    {
        public decimal? PriceGte { get; set; }
        public decimal? PriceLte { get; set; }
    }


    [HttpGet("{artworkId}")]
    public async Task<IActionResult> GetArtworkById(Guid artworkId)
    {
        var result = await _artworkService.GetArtworkByIdAsync(artworkId);
        if (result == null)
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Artwork not found!"
            });
        var resultModel = _mapper.Map<ArtworkVM>(result);
        return Ok(new ApiResponse
        {
            IsSuccess = true,
            Result = resultModel
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddArtwork([FromForm] ArtworkModel artworkModel)
    {
        if (artworkModel.ImageFiles.Count > 200)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Image files must be less than 200 files."
            });
        }

        foreach (var image in artworkModel.ImageFiles)
        {
            if (!FileValidationHelper.IsImageFormatValid(image.FileName))
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Image must have extensions: JPG, GIF, or PNG."
                });
            }
            if (!FileValidationHelper.IsImageFileSizeValid(image))
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Image must be less than 32MB."
                });
            }
        }

        try
        {
            var result = await _artworkService.AddArtworkAsync(artworkModel);
            return Ok(new ApiResponse
            {
                IsSuccess = true,
                Result = result
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

    [HttpDelete("{artworkId}")]
    public async Task<IActionResult> DeleteArtwork(Guid artworkId)
    {
        await _artworkService.DeleteArtworkAsync(artworkId);
        return Ok(new ApiResponse
        {
            IsSuccess = true,
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateArtwork([FromBody] ArtworkModel artworkModel)
    {
        Artwork artwork;
        if (artworkModel == null)
            return BadRequest();
        //try
        //{
        //    await _artworkService.AddArtworkAsync(artworkModel);
        //} catch (Exception ex)
        //{
        //    return BadRequest(ex.Message);
        //}
        //await _artworkService.UpdateArtworkAsync(artwork);
        return Ok();
    }


}
