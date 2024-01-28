using Application.Models.ZaloPayModels;

namespace Application.Services.Abstractions;

public interface IZaloPayService
{
    public ZaloPayOrderCreate BuildZaloPayOrderCreate(OrderCreateModel orderModel);
    public Task<ZaloPayOrderResult?> CreateOrder(ZaloPayOrderCreate zaloPayOrder);
    public Task<ZaloPayOrderQueryResult?> QueryOrder(string appTransId);
    public bool ValidateCallback(ZaloPayCallbackOrder callbackOrder);
    public bool ValidateRedirect(ZaloPayRedirectOrder redirectOrder);
}
