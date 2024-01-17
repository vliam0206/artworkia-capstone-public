using Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Commons;

namespace WebApi.Controllers;

[ApiController]
public class TransactionHistoriesController : ControllerBase
{
    private readonly ITransactionHistoryService _transactionHistoryService;

    public TransactionHistoriesController(ITransactionHistoryService transactionHistoryService)
    {
        _transactionHistoryService = transactionHistoryService;
    }

    //GET: api/account/{accountId}/transaction-histories
    [Route("api/account/{accountId}/transaction-histories")]
    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetTransactionHistoriesByAccount(Guid accountId)
    {
        try
        {
            var walletHistories = await _transactionHistoryService
                .GetTransactionHistoriesOfAccount(accountId);
            return Ok(walletHistories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse { ErrorMessage = ex.Message });
        }
    }
}
