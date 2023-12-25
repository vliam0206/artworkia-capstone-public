using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        //private readonly ILikeService _likeService;
        //private readonly IMapper _mapper;
        //public LikesController(ILikeService likeService, IMapper mapper)
        //{
        //    _likeService = likeService;
        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllLikes()
        //{
        //    var result = await _likeService.GetAllLikesAsync();
        //    return Ok(result);
        //}

        //[HttpGet("{likeId}")]
        //public async Task<IActionResult> GetLikeById(Guid likeId)
        //{
        //    var result = await _likeService.GetLikeByIdAsync(likeId);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}

        //[HttpPost("{artworkId}/{accountId}")]
        //public async Task<IActionResult> AddLike(Guid artworkId, Guid accountId)
        //{
        //    Like like;
        //    if (likeModel == null)
        //        return BadRequest();
        //    try
        //    {
        //        like = _mapper.Map<Like>(likeModel);
        //        await _likeService.AddLikeAsync(like);

        //    } catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok();
        //}

        //[HttpDelete("{likeId}")]
        //public async Task<IActionResult> DeleteLike(Guid likeId)
        //{
        //    try
        //    {
        //        await _likeService.DeleteLikeAsync(likeId);
        //    } catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok();
        //}

    }
}
