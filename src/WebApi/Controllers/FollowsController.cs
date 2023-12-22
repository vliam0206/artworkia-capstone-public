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


    // GET: api/follows/5/followers
    [HttpGet("{followingId}/followers")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<FollowVM>>> GetFollowers(Guid followingId)
    {
        var follows = await _followService.GetAllFollowersAsync(followingId);
        return Ok(_mapper.Map<List<FollowVM>>(follows));
    }

    // GET: api/follows/5/followings
    [HttpGet("{followerId}/followings")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<FollowVM>>> GetFollowings(Guid followerId)
    {
        var follows = await _followService.GetAllFollowingsAsync(followerId);
        return Ok(_mapper.Map<List<FollowVM>>(follows));
    }

    // POST: api/follows    
    [HttpPost]
    [Authorize] // admin & own user
    public async Task<ActionResult<Follow>> PostFollow(FollowModel model)
    {
        // check authorize
        if (!CheckAuthorize(model.FollowerId))
        {
            return Forbid();
        }
        var follow = _mapper.Map<Follow>(model);
        try
        {
            await _followService.CreateFollowAsync(follow);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return Ok(new { IsSuccess = true });
    }

    // DELETE: api/follows
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteFollow(FollowModel model)
    {
        // check authorize
        if (!CheckAuthorize(model.FollowerId))
        {
            return Forbid();
        }
        try
        {
            await _followService.DeleteFollowAsync(model.AccountId, model.FollowerId);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
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
