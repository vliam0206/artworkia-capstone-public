using Application.Filters;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin,Moderator")]
public class DashboardController : ControllerBase
{
    private readonly IDashBoardService _dashBoardService;

    public DashboardController(IDashBoardService dashBoardService)
    {
        _dashBoardService = dashBoardService;
    }

    [HttpGet("wallet-histories")]    
    public async Task<IActionResult> GetAllWalletHistoriesInPlatform([FromQuery] PagedCriteria pagedCriteria)
    {
        var result = await _dashBoardService
            .GetAllWalletHistoriesAsync(pagedCriteria.PageNumber, pagedCriteria.PageSize);
        return Ok(result);
    }

    [HttpGet("transaction-histories")]
    public async Task<IActionResult> GetAllTrasactionHistoriesInPlatform([FromQuery] PagedCriteria pagedCriteria)
    {
        var result = await _dashBoardService
            .GetAllTransactionHistoriesAsync(pagedCriteria.PageNumber, pagedCriteria.PageSize);
        return Ok(result);
    }
}
