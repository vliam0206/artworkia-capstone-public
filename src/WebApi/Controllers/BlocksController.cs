﻿using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using Application.Models;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlocksController : ControllerBase
{
    private readonly IBlockService _blockService;
    private readonly IClaimService _claimService;

    public BlocksController(IBlockService blockService, IClaimService claimService)
    {
        _blockService = blockService;
        _claimService = claimService;
    }

    // GET: api/blocks/5/blocking
    [HttpGet("/api/accounts/{blockerId}/blockings")]
    [Authorize] // admin & own user
    public async Task<ActionResult<IEnumerable<BlockVM>>> GetBlocking(Guid blockerId)
    {
        try
        {
            var blocks = await _blockService.GetBlockingsOfBlockerAsync(blockerId);
            return Ok(blocks);
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

    // GET: api/blocks/5/blocked
    [HttpGet("/api/accounts/{blockingId}/blockers")]
    [Authorize] // admin & own user
    public async Task<IActionResult> GetBlockers(Guid blockingId)
    {
        try
        {
            var blocks = await _blockService.GetBlockersOfBlockingAsync(blockingId);
            return Ok(blocks);
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

    // POST: api/blocks
    [HttpPost]
    [Authorize] 
    public async Task<ActionResult<Block>> PostBlock(BlockModel model)
    {
        try
        {
            if (_claimService.GetCurrentUserId == model.BlockedId)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "You can not block yourself."
                });
            }
            await _blockService.CreateBlockAsync(model);
            return Ok();
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

    // DELETE: api/blocks/5
    [HttpDelete]
    [Authorize] 
    public async Task<IActionResult> DeleteBlock(BlockModel model)
    {
        try
        {
            await _blockService.DeleteBlockAsync(model.BlockedId);
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

    private bool CheckAuthorize(Guid accountId)
    {
        // check authorize
        var currentRole = _claimService.GetCurrentRole;
        if (currentRole.Equals(RoleEnum.Moderator.ToString())
             || (currentRole.Equals(RoleEnum.CommonUser.ToString())
                && _claimService.GetCurrentUserId != accountId))
        {
            return false;
        }
        return true;
    }
}
