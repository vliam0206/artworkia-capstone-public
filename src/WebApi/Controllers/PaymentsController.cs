using Application.Models.ZaloPayModels;
using Application.Services.Abstractions;
using Domain.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IZaloPayService _zaloPayService;
    private readonly IWalletHistoryService _walletHistoryService;

    public PaymentsController(IZaloPayService zaloPayService,
        IWalletHistoryService walletHistoryService)
    {
        _zaloPayService = zaloPayService;
        _walletHistoryService = walletHistoryService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreatePaymentOrder(OrderCreateModel model)
    {
        try
        {
            // create (post) zalopay order
            var zaloPayOrderCreate = _zaloPayService.BuildZaloPayOrderCreate(model);
            var result = await _zaloPayService.CreateOrder(zaloPayOrderCreate);
            if (result == null || result.ReturnCode != 1)
            {
                return BadRequest(result);
            }
            // create order successfully -> save history to DB            
            var walletHistory = new WalletHistory
            {
                Amount = zaloPayOrderCreate.Amount,
                AppTransId = zaloPayOrderCreate.AppTransId,
                Type = Domain.Enums.WalletHistoryTypeEnum.Deposit
            };
            await _walletHistoryService.AddWalletHistory(walletHistory);
            // return result
            result.AppTransId = zaloPayOrderCreate.AppTransId;
            return Ok(result);
        } catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
