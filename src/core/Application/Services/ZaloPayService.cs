using Application.Commons;
using Application.Models.ZaloPayModels;
using Application.Services.Abstractions;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace Application.Services;

public class ZaloPayService : IZaloPayService
{
    private const string ZalopayBaseUrl = "https://sb-openapi.zalopay.vn/v2";
    private const string CreateOrderUrl = "/create";
    private const string QueryOrderUrl = "/query";
    private const string ServerBaseUrl = "https://huynhvanphu.id.vn";
    //private const string ServerBaseUrl = "https://localhost:7076";
    private const string CallbackUrl = "/api/payments/callback";
    private readonly int _appId;
    private readonly string _key1;
    private readonly string _key2;
    private readonly AppConfiguration _appConfiguration;
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public ZaloPayService(AppConfiguration appConfiguration, IMapper mapper, 
        IClaimService claimService)
    {
        _appConfiguration = appConfiguration;
        _httpClient = new HttpClient();
        _mapper = mapper;
        _appId = _appConfiguration.ZaloPayConfiguration.AppId;
        _key1 = _appConfiguration.ZaloPayConfiguration.Key1;
        _key2 = _appConfiguration.ZaloPayConfiguration.Key2;
        _claimService = claimService;
    }

    public ZaloPayOrderCreate BuildZaloPayOrderCreate(OrderCreateModel model)
    {
        var appTime = CurrentTime.GetTimeStamp();
        var appUser = _claimService.GetCurrentUserId.ToString();
        appUser = appUser != null ? appUser : "AnonymousUser";
        var rnd = new Random();
        var appTransId = CurrentTime.GetCurrentTime.ToString("yyMMdd") + "_" + rnd.Next(1000000);                
        var data = $"{_appId}|{appTransId}|{appUser}|{model.Amount}|{appTime}|{model.EmbedData}|{model.Item}";        
        
        var zalopayOrder = _mapper.Map<ZaloPayOrderCreate>(model);
        zalopayOrder.AppId = _appId;
        zalopayOrder.AppUser= appUser;
        zalopayOrder.AppTransId = appTransId;
        zalopayOrder.AppTime = appTime;
        zalopayOrder.Description = "Nap xu nen tang Artworkia.";
        zalopayOrder.CallbackUrl = ServerBaseUrl + CallbackUrl;
        zalopayOrder.Mac = HmacHelper.Compute(_key1, data);

        return zalopayOrder;
    }

    public async Task<ZaloPayOrderResult?> CreateOrder(ZaloPayOrderCreate zaloPayOrder)
    {
        var url = ZalopayBaseUrl + CreateOrderUrl;
        var result = await PostMethod<ZaloPayOrderResult>(url, zaloPayOrder);
        return result;
    }

    public async Task<ZaloPayOrderQueryResult?> QueryOrder(string appTransId)
    {
        var data = $"{_appId}|{appTransId}|{_key1}";
        var mac = HmacHelper.Compute(_key1, data);
        var orderQuery = new ZaloPayOrderQuery{ AppId = _appId, AppTransId = appTransId, Mac = mac };
        return await PostMethod<ZaloPayOrderQueryResult>(ZalopayBaseUrl + QueryOrderUrl, orderQuery);
    }

    public bool ValidateCallback(ZaloPayCallbackOrder callbackOrder)
    {
        var mac = HmacHelper.Compute(_key2, callbackOrder.Data);
        return mac.Equals(callbackOrder.Mac);        
    }

    public bool ValidateRedirect(ZaloPayRedirectOrder redirectOrder)
    {
        var checksumData = $"{redirectOrder.Appid}|{redirectOrder.Apptransid}|{redirectOrder.Pmcid}|{redirectOrder.Bankcode}|{redirectOrder.Amount}|{redirectOrder.Discountamount}|{redirectOrder.Status}";
        var mac = HmacHelper.Compute(_key2, checksumData);
        return mac.Equals(redirectOrder.Checksum);
    }

    private async Task<T?> PostMethod<T>(string url, IBaseFormRequest form)
    {
        var content = new FormUrlEncodedContent(form.ToDictionary());
        var response = await _httpClient.PostAsync(url, content);
        var responseString = await response.Content.ReadAsStringAsync();

        // convert json to object
        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
        var result =  JsonConvert.DeserializeObject<T>(responseString, new JsonSerializerSettings
        {
            ContractResolver = contractResolver,
            Formatting = Formatting.Indented
        });
        return result;
    }
}
