using Application.Models;
using Application.Services.Abstractions;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestsController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRequests()
    {
        var listRequest = await _requestService.GetAllRequestsAsync();
        return Ok(listRequest);
    }

    [HttpGet("{requestId}")]
    public async Task<IActionResult> GetRequestById(Guid requestId)
    {
        try
        {
            var requestVM = await _requestService.GetRequestByIdAsync(requestId);
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("creator")]
    [Authorize]
    public async Task<IActionResult> GetRequestsByCreatorId()
    {
        try
        {
            var requestVM = await _requestService.GetRequestsByCreatorIdAsync();
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("/api/services/{serviceId}/requests")]
    [Authorize]
    public async Task<IActionResult> GetRequestsByServiceId(Guid serviceId)
    {
        try
        {
            var requestVM = await _requestService.GetRequestsByServiceIdAsync(serviceId);
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpGet("/api/chatboxs/{chatboxId}/requests")]
    [Authorize]
    public async Task<IActionResult> GetRequestsByChatboxId(Guid chatboxId)
    {
        try
        {
            var requestVM = await _requestService.GetRequestsByChatboxIdIdAsync(chatboxId);
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddRequest([FromBody] RequestModel requestModel)
    {
        try
        {
            var requestVM = await _requestService.AddRequestAsync(requestModel);
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }


    [HttpGet("audience")]
    [Authorize]
    public async Task<IActionResult> GetRequestsByAudienceId()
    {
        try
        {
            var requestVM = await _requestService.GetRequestsByAudienceIdAsync();
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }


    [HttpPut("status/{requestId}")]
    [Authorize]
    public async Task<IActionResult> UpdateRequestStatus(Guid requestId, [FromBody] StateEnum requestStatus)
    {
        try
        {
            var requestVM = await _requestService.UpdateRequestStatusAsync(requestId, requestStatus);
            return Ok(requestVM);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse { ErrorMessage = ex.Message });
        }
    }
}
