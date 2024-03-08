using Application.Models;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatBoxsController : ControllerBase
{
    private readonly IChatBoxService _chatBoxService;
    private readonly IClaimService _claimService;

    public ChatBoxsController(IChatBoxService chatBoxService, IClaimService claimService)
    {
        _chatBoxService = chatBoxService;
        _claimService = claimService;
    }

    [HttpGet("/api/accounts/[controller]")]
    [Authorize]
    public async Task<IActionResult> GetChatBox()
    {
        try
        {
            var accountId = _claimService.GetCurrentUserId ?? default;
            var chats = await _chatBoxService.GetAllChatBoxByAccountIdAsync(accountId);
            return Ok(chats);
        } catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{chatboxId}")]
    public async Task<IActionResult> GetChatBoxById(Guid chatboxId)
    {
        var chat = await _chatBoxService.GetChatBoxByIdAsync(chatboxId);
        return Ok(chat);
    }
}
