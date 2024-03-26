using Application.Models;
using Application.Services;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LicenseTypesController : ControllerBase
{
    private readonly ILicenseTypeService _licenseTypeService;

    public LicenseTypesController(ILicenseTypeService licenseTypeService)
    {
        _licenseTypeService = licenseTypeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<LicenseTypeVM>>> GetAllLicenseTypesAsync()
    {
        try
        {
            var licenseTypes = await _licenseTypeService.GetAllLicenseTypesAsync();
            return Ok(licenseTypes);
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

    [HttpGet("{licenseTypeId}")]
    public async Task<ActionResult<LicenseTypeVM>> GetLicenseTypeByIdAsync(Guid licenseTypeId)
    {
        try
        {
            var licenseType = await _licenseTypeService.GetLicenseTypeByIdAsync(licenseTypeId);
            return Ok(licenseType);
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
