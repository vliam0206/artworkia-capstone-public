﻿using Application.Models;
using Application.Services;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProposalAssetsController : ControllerBase
{
    private readonly IProposalAssetService _proposalAssetService;

    public ProposalAssetsController(IProposalAssetService proposalAssetService)
    {
        _proposalAssetService = proposalAssetService;
    }

    [HttpGet("{proposalId}")]
    [Authorize]
    public async Task<IActionResult> GetProposalAssetsOfProposal(Guid proposalId)
    {
        try
        {
            var result = await _proposalAssetService.GetProposalAssetsOfProposalAsync(proposalId);
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
    public async Task<IActionResult> CreateProposalAssets([FromForm] ProposalAssetModel model)
    {
        try
        {
            var result = await _proposalAssetService.AddProposalAssetAsync(model);
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
}
