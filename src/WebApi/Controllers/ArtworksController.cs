using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utils;
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
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetArtworksBySearch([FromQuery] SearchArtworkCriteria searchArtworkCriteria)
    {
        var result = await _artworkService.GetArtworksBySearchAsync(searchArtworkCriteria);

        return Ok(result);
    }


    [HttpGet("{artworkId}")]
    public async Task<IActionResult> GetArtworkById(Guid artworkId)
    {
        try
        {
            var result = await _artworkService.GetArtworkByIdAsync(artworkId);
            var resultModel = _mapper.Map<ArtworkVM>(result);
            return Ok(resultModel);
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
    public async Task<IActionResult> AddArtwork([FromForm] ArtworkModel artworkModel)
    {
        if (!FileValidationHelper.IsImageFormatValid(artworkModel.Thumbnail.FileName))
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Image must have extensions: JPG, JPEG, PNG, GIF, BMP, TIFF, TIF, WEBP, or SVG."
            });
        }
        if (!FileValidationHelper.IsAvatarFileSizeValid(artworkModel.Thumbnail))
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Thumbnail must be less than 5MB."
            });
        }

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
                    ErrorMessage = "Image must have extensions: JPG, JPEG, PNG, GIF, BMP, TIFF, TIF, WEBP, or SVG."
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

        // kiem tra cac dieu kien cua asset file
        if (artworkModel.AssetFiles != null)
        {
            // toi da 5 file
            if (artworkModel.AssetFiles.Count > 5)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Asset files must be less than 5 files."
                });
            }

            // kiem tra dinh dang va kich thuoc file
            foreach (var asset in artworkModel.AssetFiles)
            {
                if (!FileValidationHelper.IsAssetFormatValid(asset.File.FileName))
                {
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "File must have extensions: ABR, AI, ASE, " +
                        "DNG, DOC, DOCX, EPS, GIF, INDD, JPEG, JPG, OTF, PDF, PNG, " +
                        "PPT, PPTX, PSD, RAW, SVG, TIF, TIFF, TTF, TXT, WEBP, WOFF, " +
                        "WOFF2, XLS, XLSX, XMP, ZIP, RAR."
                    });
                }
                if (!FileValidationHelper.IsAssetFileSizeValid(asset.File))
                {
                    return BadRequest(new ApiResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "File must be less than 500MB."
                    });
                }
            }
        }

        try
        {
            var result = await _artworkService.AddArtworkAsync(artworkModel);
            return CreatedAtAction(nameof(GetArtworkById), 
                new { artworkId = result }, result);
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
    [Authorize]
    public async Task<IActionResult> DeleteArtwork(Guid artworkId)
    {
        try
        {
            await _artworkService.DeleteArtworkAsync(artworkId);
            return NoContent();

        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpPut("{artworkId}")]
    [Authorize]
    public async Task<IActionResult> UpdateArtwork(Guid artworkId, [FromBody] ArtworkEM artworkEM)
    {
        try
        {
            await _artworkService.UpdateArtworkAsync(artworkId, artworkEM);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }
}
