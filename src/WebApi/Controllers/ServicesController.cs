using Application.Filters;
using Application.Models;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;
namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServicesController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllServices([FromQuery] ServiceCriteria criteria)
    {
        var listService = await _serviceService.GetAllServicesAsync(criteria);
        return Ok(listService);
    }

    [HttpGet("{serviceId}")]
    public async Task<IActionResult> GetServiceById(Guid serviceId)
    {
        try
        {
            var serviceVM = await _serviceService.GetServiceByIdAsync(serviceId);
            return Ok(serviceVM);
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddService([FromForm] ServiceModel serviceModel)
    {
        try
        {
            var serviceVM = await _serviceService.AddServiceAsync(serviceModel);
            return CreatedAtAction(nameof(GetServiceById), 
                new { serviceId = serviceVM.Id }, serviceVM);
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message,
            });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpDelete("{serviceId}")]
    [Authorize]
    public async Task<IActionResult> DeleteService(Guid serviceId)
    {
        try
        {
            await _serviceService.DeleteServiceAsync(serviceId);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message,
            });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }

    [HttpPut("{serviceId}")]
    [Authorize]
    public async Task<IActionResult> UpdateService(Guid serviceId, [FromForm] ServiceEM serviceEM)
    {
        try
        {
            await _serviceService.UpdateServiceAsync(serviceId, serviceEM);
            return NoContent();
        } catch (NullReferenceException ex)
        {
            return NotFound(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message,
            });
        } catch (Exception ex)
        {
            return BadRequest(new ApiResponse
            {
                IsSuccess = false,
                ErrorMessage = ex.Message
            });
        }
    }
}
