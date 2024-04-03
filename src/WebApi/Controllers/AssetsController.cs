﻿using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssetsController : ControllerBase
{
    private readonly IAssetService _assetService;
    private readonly IMapper _mapper;

    public AssetsController(
        IAssetService assetService, 
        IMapper mapper)
    {
        _assetService = assetService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssets([FromQuery] AssetCriteria criteria)
    {
        var result = await _assetService.GetAllAssetsAsync(criteria);
        return Ok(result);
    }

    [HttpGet("{assetId}")]
    public async Task<IActionResult> GetAssetById(Guid assetId)
    {
        try
        {
            var result = await _assetService.GetAssetByIdAsync(assetId);
            if (result == null)
                return NotFound();
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

    [HttpGet("download/{assetId}")]
    [Authorize]
    public async Task<IActionResult> GetAssetDownloadById(Guid assetId)
    {
        try
        {
            var link = await _assetService.GetDownloadUriAssetAsync(assetId);
            return Ok(new { link });
        } catch (NullReferenceException ex)
        {
            return BadRequest(new ApiResponse
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

    [HttpGet("moderation/download/{assetId}")]
    [Authorize(Roles = "Moderator,Admin")]
    public async Task<IActionResult> GetAssetDownloadForModeration(Guid assetId)
    {
        try
        {
            var link = await _assetService.GetDownloadUriAssetForModerationAsync(assetId);
            return Ok(new { link });
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(new ApiResponse
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

    //[HttpGet("download-alt/{assetId}")]
    //[Authorize]
    //public async Task<IActionResult> GetAssetDownloadAlternativeAById(Guid assetId)
    //{
    //    try
    //    {
    //        var link = await _assetService.GetDownloadUriAssetAlternativeAsync(assetId);
    //        return Ok(new { link });
    //    }
    //    catch (NullReferenceException ex)
    //    {
    //        return BadRequest(new ApiResponse
    //        {
    //            IsSuccess = false,
    //            ErrorMessage = ex.Message
    //        });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new ApiResponse
    //        {
    //            IsSuccess = false,
    //            ErrorMessage = ex.Message
    //        });
    //    }
    //}

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAsset([FromForm] AssetModel assetModel)
    {
        try
        {
            var asset = await _assetService.AddAssetAsync(assetModel);
            return CreatedAtAction(nameof(GetAssetById), new { assetId = asset.Id }, asset);
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

    [HttpPut("{assetId}")]
    [Authorize]
    public async Task<IActionResult> UpdateAsset(Guid assetId, [FromBody] AssetEM assetEM)
    {
        try
        {
            await _assetService.UpdateAssetAsync(assetId, assetEM);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return BadRequest(new ApiResponse
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

    [HttpDelete("{assetId}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsset(Guid assetId)
    {
        try
        {
            await _assetService.DeleteAssetAsync(assetId);
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
