using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Application.Services.GoogleStorage;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utils;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public AssetsController(
        IAssetService assetService,
        IMapper mapper,
        IStorageService storageService)
    {
        _assetService = assetService;
        _mapper = mapper;
        _storageService = storageService;
    }

    [HttpPost("google")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        try
        {
            var check = await _storageService.UploadFileToCloudStorage(file, file.FileName, "Artwork");
            //return CreatedAtAction(nameof(GetAssetById), new { assetId = asset.Id }, asset);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("google")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        try
        {
            var stream = await _storageService.DownloadFileFromCloudStorage(fileName, "Artwork");
            return File(stream, "application/octet-stream", fileName);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssets([FromQuery] AssetCriteria criteria)
    {
        try
        {
            var result = await _assetService.GetAllAssetsAsync(criteria);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("{assetId}")]
    public async Task<IActionResult> GetAssetById(Guid assetId)
    {
        try
        {
            var result = await _assetService.GetAssetByIdAsync(assetId);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("download/{assetId}")]
    [Authorize]
    public async Task<IActionResult> GetAssetDownloadById(Guid assetId)
    {
        try
        {
            var link = await _assetService.GetDownloadUriAssetAsync(assetId);
            return Ok(new { link });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("moderation/download/{assetId}")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> GetAssetDownloadForModeration(Guid assetId)
    {
        try
        {
            var link = await _assetService.GetDownloadUriAssetForModerationAsync(assetId);
            return Ok(new { link });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAsset([FromForm] AssetModel assetModel)
    {
        try
        {
            var asset = await _assetService.AddAssetAsync(assetModel);
            return CreatedAtAction(nameof(GetAssetById), new { assetId = asset.Id }, asset);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpPut("{assetId}")]
    [Authorize]
    public async Task<IActionResult> UpdateAsset(Guid assetId, [FromBody] AssetEM assetEM)
    {
        try
        {
            await _assetService.UpdateAssetAsync(assetId, assetEM);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpDelete("{assetId}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsset(Guid assetId)
    {
        try
        {
            await _assetService.DeleteAssetAsync(assetId);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }
}
