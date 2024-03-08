using Application.Models;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet("/api/chatbox/{chatBoxId}/[controller]")]
    [Authorize] // not check authorized yet
    public async Task<IActionResult> GetMessagesByChatId(Guid chatBoxId)
    {
        try
        {
            var messages = await _messageService.GetAllMessageAsync(chatBoxId);
            return Ok(messages);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostMessage(MessageModel model)
    {
        try
        {
            var newMessage = await _messageService.SendMessageAsync(model);
            return Ok(newMessage);
        } catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
