using Application.Models;
using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LikesController : ControllerBase
{
    private readonly ILikeService _likeService;
    private readonly IClaimService _claimService;
    private readonly IMapper _mapper;

    public LikesController(ILikeService likeService, 
        IClaimService claimService, 
        IMapper mapper)
    {
        _likeService = likeService;
        _claimService = claimService;
        _mapper = mapper;
    }

    // GET: api/likes/5/artworks
    [HttpGet("{artworkId}/artworks")]
    [Authorize]
    public async Task<IActionResult> GetAllLikesOfArtwork(Guid artworkId)
    {
        var result = await _likeService.GetAllLikesOfArtworkAsync(artworkId);
        return Ok(result);
    }

    // GET: api/likes/5/accounts
    [HttpGet("{accountId}/accounts")]
    [Authorize]
    public async Task<IActionResult> GetAllLikesOfAccount(Guid accountId)
    {
        var result = await _likeService.GetAllLikesOfAccountAsync(accountId);
        return Ok(result);
    }

    // POST: api/likes
    [HttpPost]
    [Authorize] // admin & own user
    public async Task<IActionResult> AddLike(LikeModel model)
    {
        try
        {
            await _likeService.CreateLikeAsync(model);
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

    // DELETE: api/likes/5
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteLike(LikeModel model)
    {
        var like = _mapper.Map<Like>(model);
        try
        {
            await _likeService.DeleteLikeAsync(model.ArtworkId);
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
