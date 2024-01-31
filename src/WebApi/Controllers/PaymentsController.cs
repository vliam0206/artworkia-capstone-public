using Application.Commons;
using Application.Models.ZaloPayModels;
using Application.Services.Abstractions;
using Domain.Entitites;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IZaloPayService _zaloPayService;
    private readonly IWalletHistoryService _walletHistoryService;
    private readonly IWalletService _walletService;

    public PaymentsController(IZaloPayService zaloPayService,
        IWalletHistoryService walletHistoryService,
        IWalletService walletService)
    {
        _zaloPayService = zaloPayService;
        _walletHistoryService = walletHistoryService;
        _walletService = walletService;
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
                Amount = zaloPayOrderCreate.Amount / 1000, // amount is coins
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

    [HttpPost("callback")]
    public async Task<IActionResult> Callback([FromBody] dynamic cbdata)
    {
        var result = new Dictionary<string, object>();
        try
        {
            var dataStr = Convert.ToString(cbdata["data"]);
            var reqMac = Convert.ToString(cbdata["mac"]);
            var type = Convert.ToString(cbdata["type"]);
            var callbackOrder = new ZaloPayCallbackOrder { Type = type, Mac = reqMac, Data = dataStr };

            // check valid callback (from ZaloPay server)
            if (!_zaloPayService.ValidateCallback(callbackOrder))
            {
                // invalid callback
                result["return_code"] = -1;
                result["return_message"] = "mac not equal";
            } else
            {   // payment success                
                // update order status
                var dataJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataStr);
                await _walletHistoryService.UpdateWalletHistoryStatus(dataJson["app_trans_id"], 
                                                                      TransactionStatusEnum.Success);
                // update coins in db
                var accountId = Guid.Parse(dataJson["app_user"]);
                var amount = dataJson["amount"] / 1000;
                await _walletService.DepositCoinsAsync(accountId, amount);

                // return result
                result["return_code"] = 1;
                result["return_message"] = "success";
            }

        }
        catch (Exception ex)
        {
            result["return_code"] = 0; // ZaloPay server will callback again (up to 3 times)
            result["return_message"] = ex.Message;
        }
        return Ok(result);
    }

    [HttpGet("query-order/{appTransId}")]
    public async Task<IActionResult> QueryOrder(string appTransId)
    {
        try
        {
            // query zalo pay order status
            var result = await _zaloPayService.QueryOrder(appTransId);
            // return result
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
