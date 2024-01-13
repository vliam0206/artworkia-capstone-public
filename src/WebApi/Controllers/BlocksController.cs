using Application.Services;
using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;
using WebApi.ViewModels;
using Domain.Enums;
using WebApi.Services;
using AutoMapper;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlocksController : ControllerBase
{
    private readonly IBlockService _blockService;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public BlocksController(IBlockService blockService, IClaimService claimService, IMapper mapper)
    {
        _blockService = blockService;
        _claimService = claimService;
        _mapper = mapper;
    }

    // GET: api/blocks/5/blocked
    [HttpGet("{blockerId}/blocked")]
    public async Task<ActionResult<IEnumerable<BlockVM>>> GetBlocked(Guid blockerId)
    {
        var blocks = await _blockService.GetAllBlockOfBlockedAsync(blockerId);
        return Ok(_mapper.Map<List<BlockVM>>(blocks));
    }

    // GET: api/blocks/5/blocking
    [HttpGet("{blockedId}/blocking")]
    public async Task<ActionResult<IEnumerable<BlockVM>>> GetBlocking(Guid blockedId)
    {
        var blocks = await _blockService.GetAllBlockOfBlockingAsync(blockedId);
        return Ok(_mapper.Map<List<BlockVM>>(blocks));
    }

    // POST: api/blocks
    [HttpPost]
    [Authorize] // admin & own user
    public async Task<ActionResult<Block>> PostBlock(BlockModel model)
    {
        // check authorize
        if (!CheckAuthorize(model.BlockingId))
        {
            return Forbid();
        }
        var block = _mapper.Map<Block>(model);
        try
        {
            await _blockService.CreateBlockAsync(block);
        } catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
        return Ok(new { IsSuccess = true });
    }

    // DELETE: api/blocks/5
    [HttpDelete]
    [Authorize] // admin & own user
    public async Task<IActionResult> DeleteBlock(BlockModel model)
    {
        // check authorize
        if (!CheckAuthorize(model.BlockingId))
        {
            return Forbid();
        }
        try
        {
            await _blockService.DeleteBlockAsync(model.BlockingId, model.BlockedId);
        } catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        } catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
        return Ok(new { IsSuccess = true });
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
