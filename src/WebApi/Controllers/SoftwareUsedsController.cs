using Application.Services.Abstractions;
using Domain.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SoftwareUsedsController : ControllerBase
{
    private readonly ISoftwareUsedService _softwareUsedService;

    public SoftwareUsedsController(ISoftwareUsedService softwareUsedService)
    {
        _softwareUsedService = softwareUsedService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSoftwareUseds()
    {
        try
        {
            var softwareUseds = await _softwareUsedService.GetAllSoftwareUsedAsync();
            return Ok(softwareUseds);
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

    [HttpGet("{softwareUsedId}")]
    public async Task<IActionResult> GetSoftwareUsedById(Guid softwareUsedId)
    {
        try
        {
            var softwareUsed = await _softwareUsedService.GetSoftwareUsedByIdAsync(softwareUsedId);
            return Ok(softwareUsed);
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
