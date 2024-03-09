using Application.Commons;
using Application.Filters;
using Application.Models;
using Application.Services;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Enums;
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
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public ArtworksController(
        IArtworkService artworkService, 
        ITagService tagService,
        IMapper mapper
        )
    {
        _artworkService = artworkService;
        _tagService = tagService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArtworks([FromQuery] ArtworkCriteria criteria)
    {
        var result = await _artworkService.GetAllArtworksAsync(criteria);
        return Ok(result);
    }

    [HttpGet("privacy-enum")]
    public IActionResult GetArtworkPrivacyEnum()
    {
        var privacyEnums = Enum.GetValues(typeof(PrivacyEnum))
                .Cast<PrivacyEnum>().Select(r => new { Id = (int)r, Name = r.ToString() });
        return Ok(privacyEnums);
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

    [HttpGet("{artworkId}/duplication")]
    public async Task<IActionResult> GetArtworksDuplicate(Guid artworkId)
    {
        try
        {
            var result = await _artworkService.GetArtworksDuplicateAsync(artworkId);
            return Ok(result);
        }
        catch (NullReferenceException ex)
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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddArtwork([FromForm] ArtworkModel artworkModel)
    {
        #region Validate artwork model
        var tagValidationResult = ValidateTag(artworkModel.Tags);
        if (!tagValidationResult.IsSuccess)
        {
            return BadRequest(tagValidationResult);
        }

        var categoryValidationResult = ValidateCategory(artworkModel.Categories);
        if (!categoryValidationResult.IsSuccess)
        {
            return BadRequest(categoryValidationResult);
        }

        var thumbnailValidationResult = ValidateThumbnail(artworkModel.Thumbnail);
        if (!thumbnailValidationResult.IsSuccess)
        {
            return BadRequest(thumbnailValidationResult);
        }

        var imageFilesValidationResult = ValidateImageFiles(artworkModel.ImageFiles);
        if (!imageFilesValidationResult.IsSuccess)
        {
            return BadRequest(imageFilesValidationResult);
        }

        if (artworkModel.AssetFiles != null)
        {
            var assetFilesValidationResult = ValidateAssetFiles(artworkModel.AssetFiles);
            if (!assetFilesValidationResult.IsSuccess)
            {
                return BadRequest(assetFilesValidationResult);
            }
        }
        #endregion

        try
        {
            var result = await _artworkService.AddArtworkAsync(artworkModel);
            return CreatedAtAction(nameof(GetArtworkById),
                new { artworkId = result.Id }, result);
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
    public async Task<IActionResult> UpdateArtwork(Guid artworkId, [FromForm] ArtworkEM artworkEM)
    {
        #region Validate artwork model
        if (artworkEM.Tags != null)
        {
            var tagValidationResult = ValidateTag(artworkEM.Tags);
            if (!tagValidationResult.IsSuccess)
            {
                return BadRequest(tagValidationResult);
            }
        }

        if (artworkEM.Categories != null)
        {
            var categoryValidationResult = ValidateCategory(artworkEM.Categories);
            if (!categoryValidationResult.IsSuccess)
            {
                return BadRequest(categoryValidationResult);
            }
        }

        if (artworkEM.Thumbnail != null)
        {
            var thumbnailValidationResult = ValidateThumbnail(artworkEM.Thumbnail);
            if (!thumbnailValidationResult.IsSuccess)
            {
                return BadRequest(thumbnailValidationResult);
            }
        }

        if (artworkEM.ImageFiles != null)
        {
            var imageFilesValidationResult = ValidateImageFiles(artworkEM.ImageFiles);
            if (!imageFilesValidationResult.IsSuccess)
            {
                return BadRequest(imageFilesValidationResult);
            }
        }
        #endregion

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

    [HttpDelete("softdelete/{artworkId}")]
    [Authorize]
    public async Task<IActionResult> SoftDeleteArtwork(Guid artworkId)
    {
        try
        {
            await _artworkService.SoftDeleteArtworkAsync(artworkId);
            return NoContent();

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

    [HttpGet, Route("/api/moderation/[controller]")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> GetAllArtworksForModerator([FromQuery] ArtworkCriteria criteria)
    {
        var result = await _artworkService.GetAllArtworksForModerationAsync(criteria);
        return Ok(result);
    }

    [HttpPut, Route("/api/moderation/[controller]/{artworkId}/state")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> UpdateArtworkStatusForModerator(Guid artworkId, [FromBody] StateEnum state)
    {
        try
        {
            await _artworkService.UpdateArtworkStateAsync(artworkId, state);
            return NoContent();
        }
        catch (NullReferenceException ex)
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

    private ApiResponse ValidateThumbnail(IFormFile thumbnail)
    {
        if (!FileValidationHelper.IsImageFormatValid(thumbnail.FileName))
        {
            return new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Image must have extensions: JPG, JPEG, PNG, GIF, BMP, WEBP, or SVG."
            };
        }

        if (!FileValidationHelper.IsAvatarFileSizeValid(thumbnail))
        {
            return new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Thumbnail must be less than 5MB."
            };
        }

        return new ApiResponse { IsSuccess = true };
    }

    // so tag toi da la 30, moi tag phai hop le
    private ApiResponse ValidateTag(List<string> Tags)
    {
        if (Tags.Count > 30)
        {
            return new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Number of tag must be less than 30."
            };
        }

        foreach (var tag in Tags)
        {
            if (!_tagService.IsTagValid(tag))
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Tag name '{tag}' is invalid (only contains uppercase, lowercase, digits, space, 2-30 characters)."
                };
            }
        }

        return new ApiResponse { IsSuccess = true };
    }
    private ApiResponse ValidateCategory(List<Guid> Categories)
    {
        if (Categories.Count > 3)
        {
            return new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Number of category must be less than 3."
            };
        }

        return new ApiResponse { IsSuccess = true };
    }


    private ApiResponse ValidateImageFiles(List<IFormFile> imageFiles)
    {
        if (imageFiles.Count > 30)
        {
            return new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = "Image files must be less than 30 files."
            };
        }

        foreach (var image in imageFiles)
        {
            if (!FileValidationHelper.IsImageFormatValid(image.FileName))
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Image must have extensions: JPG, JPEG, PNG, GIF, BMP, WEBP, or SVG."
                };
            }

            if (!FileValidationHelper.IsImageFileSizeValid(image))
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Image must be less than 16MB."
                };
            }
        }

        return new ApiResponse { IsSuccess = true };
    }

    private ApiResponse ValidateAssetFiles(List<SingleAssetModel> assetFiles)
    {
        {
            if (assetFiles.Count > 5)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Asset files must be less than 5 files."
                };
            }

            foreach (var asset in assetFiles)
            {
                if (!FileValidationHelper.IsAssetFormatValid(asset.File.FileName))
                {
                    return new ApiResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "File must have extensions: ABR, AI, ASE, DNG, DOC, DOCX, EPS, GIF, INDD, JPEG, JPG, OTF, PDF, PNG, PPT, PPTX, PSD, RAW, SVG, TIF, TIFF, TTF, TXT, WEBP, WOFF, WOFF2, XLS, XLSX, XMP, ZIP, RAR."
                    };
                }

                if (!FileValidationHelper.IsAssetFileSizeValid(asset.File))
                {
                    return new ApiResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = "File must be less than 500MB."
                    };
                }
            }
        }

        return new ApiResponse { IsSuccess = true };
    }
}

