using Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using WebApi.ViewModels.Commons;
using Microsoft.AspNetCore.Authorization;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTransactionsController : ControllerBase
    {
        private readonly IAssetTransactionService _assetTransactionService;

        public AssetTransactionsController(IAssetTransactionService assetTransactionService)
        {
            _assetTransactionService = assetTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssetTransactions()
        {
            try
            {
                var assetTransactions = await _assetTransactionService.GetAllAssetTransactionsAsync();
                return Ok(assetTransactions);
            } catch (Exception ex)
            {
                return BadRequest(new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpGet("{assetTransactionId}")]
        public async Task<IActionResult> GetAssetTransactionById(Guid assetTransactionId)
        {
            try
            {
                var assetTransaction = await _assetTransactionService.GetAssetTransactionByIdAsync(assetTransactionId);
                return Ok(assetTransaction);
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
        public async Task<IActionResult> CreateAssetTransaction([FromBody] AssetTransactionModel assetTransactionModel)
        {
            try
            {
                var assetTransaction = await _assetTransactionService.CreateAssetTransactionAsync(assetTransactionModel);
                return CreatedAtAction(
                    nameof(GetAssetTransactionById), new { assetTransactionId = assetTransaction.Id }
                    , assetTransaction);
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
    }
}
