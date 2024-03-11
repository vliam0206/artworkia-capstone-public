using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Application.Models.ZaloPayModels;

public class ZaloPayCallbackOrder
{
    public int Type { get; set; }
    public string Mac { get; set; } = default!;
    public string Data { get; set; } = default!;
    public CallbackOrderData? ToCallbackOrderData()
    {
        // convert json to object
        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
        var result = JsonConvert.DeserializeObject<CallbackOrderData>(this.Data, new JsonSerializerSettings
        {
            ContractResolver = contractResolver,
            Formatting = Formatting.Indented
        });
        return result;
    }
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
