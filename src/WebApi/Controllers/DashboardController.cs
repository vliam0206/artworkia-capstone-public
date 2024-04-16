using Application.Filters;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Utils;

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
    
    [HttpGet("asset-transaction-statistic")]
    public async Task<IActionResult> GetAssetTransactionStatistic(DateTime startTime, DateTime? endTime = null)
    {
        try
        {
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetAssetTransactionStatisticAsync(startTime, endTime);
            return Ok(result);
        }         
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("percentage-category-asset-transaction-statistic")]
    public async Task<IActionResult> GetPercentageCategoryOfAssetTransStatistic(DateTime? startTime = null, DateTime? endTime = null)
    {
        try
        {
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetPercentageCategoryOfAssetTransStatisticAsync(startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("top-creator-asset-transaction-statistic")]
    public async Task<IActionResult> GetTopCreatorOfAssetTransStatistic(int topNumber = 10, DateTime? startTime = null, DateTime? endTime = null)
    {
        try
        {
            if (topNumber < 1 || topNumber > 1000)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Số lượng top creator phải lớn hơn 0 và nhỏ hơn 1000." });
            }
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetTopCreatorOfAssetTransStatisticAsync(topNumber, startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("proposal-statistic")]
    public async Task<IActionResult> GetProposalStatistic(DateTime? startTime = null, DateTime? endTime = null)
    {
        try
        {
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetProposalByDateStatisticAsync(startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("percentage-category-proposal-statistic")]
    public async Task<IActionResult> GetPercentageCategoryOfProposalStatistic(DateTime? startTime = null, DateTime? endTime = null)
    {
        try
        {
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetPercentageCategoryOfProposalStatisticAsync(startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("top-creator-proposal-statistic")]
    public async Task<IActionResult> GetTopCreatorOfProposalStatistic(int topNumber = 10, DateTime? startTime = null, DateTime? endTime = null)
    {
        try
        {
            if (topNumber < 1 || topNumber > 1000)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Số lượng top creator phải lớn hơn 0 và nhỏ hơn 1000." });
            }
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetTopCreatorOfProposalStatisticAsync(topNumber, startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("top-service-creator-statistic")]
    public async Task<IActionResult> GetTopServiceOfCreatorStatistic(int topNumber = 10, DateTime? startTime = null, DateTime? endTime = null)
    {
        try
        {
            if (topNumber < 1 || topNumber > 1000)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Số lượng top creator phải lớn hơn 0 và nhỏ hơn 1000." });
            }
            if (startTime > endTime)
            {
                return BadRequest(new ApiResponse { ErrorMessage = "Thời gian bắt đầu không lớn hơn thời gian kết thúc." });
            }
            var result = await _dashBoardService.GetTopServiceOfCreatorStatisticAsync(topNumber, startTime, endTime);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
