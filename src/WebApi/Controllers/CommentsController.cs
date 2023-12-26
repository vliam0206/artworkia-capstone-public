using Application.Services.Abstractions;
using AutoMapper;
using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;   
    private readonly IMapper _mapper;   
    public CommentsController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    // api/artworks/5/comments
    [Route("api/artworks/{artworkId}/comments")]
    [HttpGet]
    public async Task<IActionResult> GetCommentsOfArtwork(Guid artworkId)
    {
        try
        {
            var comments = _mapper.Map<List<CommentVM>>(
                await _commentService.GetCommentsByArtworkWithRepliesAsync(artworkId));
            return Ok(comments);
        } catch (Exception ex)
        {
            return BadRequest(new {ErrorMessage = ex.Message});
        }
    }

    // api/comments/5
    [Route("api/comments/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetComment(Guid id)
    {
        return Ok(_mapper.Map<CommentVM>(
                await _commentService.GetCommentByIdAsync(id)));
    }

    // api/artworks/5/comments
    [Route("api/artworks/{artworkId}/comments")]
    [HttpPost]
    [Authorize(Roles = "CommonUser")]
    public async Task<IActionResult> PostComment(Guid artworkId, [FromBody] CommentModel model)
    {        
        try
        {
            var comment = await _commentService.AddCommentAsync(artworkId, model.CommentText);
            return CreatedAtAction(nameof(GetComment), new {id = comment.Id}, comment);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // api/artworks/5/comments
    [Route("api/comments/{id}/replies")]
    [HttpPost]
    [Authorize(Roles = "CommonUser")]
    public async Task<IActionResult> ReplyComment(Guid id, [FromBody] CommentModel model)
    {
        try
        {
            var comment = await _commentService.ReplyCommentAsync(id, model.CommentText);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // api/comments/5
    [Route("api/comments/{id}")]
    [HttpPut]
    [Authorize(Roles = "CommonUser")]
    public async Task<IActionResult> PutComment(Guid id, [FromBody] CommentModel model)
    {
        try
        {
            await _commentService.EditCommentAsync(id, model.CommentText);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // api/comments/5
    [Route("api/comments/{id}")]
    [HttpDelete]
    [Authorize(Roles = "CommonUser,Moderator,Admin")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {        
        try
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
        catch(ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Forbid();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }    
}
