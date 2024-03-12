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
using Microsoft.Identity.Client;
using Application.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowsController : ControllerBase
{
    private readonly IFollowService _followService;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public FollowsController(IFollowService followService, 
        IClaimService claimService, 
        IMapper mapper)
    {
        _followService = followService;
        _claimService = claimService;
        _mapper = mapper;
    }

    // GET: /api/accounts/6/followings
    [HttpGet("/api/accounts/{followerId}/followings")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<FollowingVM>>> GetFollowings(Guid followerId)
    {
        try
        {
            var follows = await _followService.GetAllFollowingsAsync(followerId);
            return Ok(follows);
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


    // GET: api/accounts/6/followers
    [HttpGet("/api/accounts/{followingId}/followers")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<FollowerVM>>> GetFollowers(Guid followingId)
    {

        try
        {
            var follows = await _followService.GetAllFollowersAsync(followingId);
            return Ok(follows);
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

    // POST: api/follows    
    [HttpPost]
    [Authorize] // own user
    public async Task<ActionResult<Follow>> PostFollow(FollowModel model)
    {
        try
        {
            await _followService.CreateFollowAsync(model);
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

    // DELETE: api/follows
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteFollow(FollowModel model)
    {
        try
        {
            await _followService.DeleteFollowAsync(model);
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

    // GET: api/follows/is-existed
    [HttpGet("is-existed/{accountId}")]
    [Authorize]
    public async Task<IActionResult> IsFollowExisted(Guid accountId)
    {
        try
        {
            var isExisted = await _followService.IsFollowedAsync(accountId);
            return Ok(isExisted);
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
