using System.Text.Json;

namespace Application.Models.ZaloPayModels;

public class ZaloPayCallbackOrder
{
    public string Type { get; set; } = default!;
    public string Mac { get; set; } = default!;
    public string Data { get; set; } = default!;
    public CallbackOrderData? ToCallbackOrderData()
        => JsonSerializer.Deserialize<CallbackOrderData>(Data);
}

public class CallbackOrderData
{
    public int AppId { get; set; }
    public string AppTransId { get; set; } = default!;
    public long AppTime { get; set; }
    public string AppUser { get; set; } = default!;
    public long Amount { get; set; }
    public string EmbedData { get; set; } = default!;
    public string Item { get; set; } = default!;
    public long ZpTransId { get; set; }
    public long ServerTime { get; set; }
    public int Channel { get; set; }
    public string MerchantUserId { get; set; } = default!;
    public long UserFeeAmount { get; set; }
    public long DiscountAmount { get; set; }
}
