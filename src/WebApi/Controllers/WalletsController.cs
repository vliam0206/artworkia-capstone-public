﻿using Application.Models;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[ApiController]
public class WalletsController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletsController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [Route("api/[controller]/{walletId}")]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetWalletById(Guid walletId)
    {
        try
        {
            var result = await _walletService.GetWalletByIdAsync(walletId);
            return Ok(result);
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [Route("api/account/{userId}/[controller]")]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetWalletByUserId(Guid userId)
    {
        try
        {
            var result = await _walletService.GetWalletByAccountIdAsync(userId);
            return Ok(result);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [Route("api/[controller]/{walletId}")]
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateWallet(Guid walletId, WalletEM walletEM)
    {
        try
        {
            await _walletService.UpdateWalletAsync(walletId, walletEM);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }
}