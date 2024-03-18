using Application.AppConfigurations;
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
    private readonly string ZalopayBaseUrl;
    private const string CreateOrderUrl = "/v2/create";
    private const string QueryOrderUrl = "/v2/query";
    private const string QueryUserUrl = "/v2/disbursement/user";

    private const string ServerBaseUrl = "https://huynhvanphu.id.vn";
    private const string CallbackUrl = "/api/payments/callback";

    private readonly ZaloPayConfiguration _zaloPayConfig;
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public ZaloPayService(AppConfiguration appConfiguration, IMapper mapper,
        IClaimService claimService)
    {
        _zaloPayConfig = appConfiguration.ZaloPayConfiguration;
        _httpClient = new HttpClient();
        _mapper = mapper;
        ZalopayBaseUrl = _zaloPayConfig.BaseUrl;
        _claimService = claimService;
    }

    public ZPCreateOrderRequest BuildZaloPayOrderCreate(OrderCreateModel model)
    {
        var appTime = CurrentTime.GetTimeStamp();
        var appUser = _claimService.GetCurrentUserId.ToString();
        appUser = appUser != null ? appUser : "AnonymousUser";
        var rnd = new Random();
        var appTransId = CurrentTime.GetCurrentTime.ToString("yyMMdd") + "_" + rnd.Next(1000000);                
        var data = $"{_zaloPayConfig.AppId}|{appTransId}|{appUser}|{model.Amount}|{appTime}|{model.EmbedData}|{model.Item}";        
        
        var zalopayOrder = _mapper.Map<ZPCreateOrderRequest>(model);
        zalopayOrder.AppId = _zaloPayConfig.AppId;
        zalopayOrder.AppUser= appUser;
        zalopayOrder.AppTransId = appTransId;
        zalopayOrder.AppTime = appTime;
        zalopayOrder.Description = "Nap xu nen tang Artworkia.";
        zalopayOrder.CallbackUrl = ServerBaseUrl + CallbackUrl;
        zalopayOrder.Mac = HmacHelper.Compute(_zaloPayConfig.Key1, data);

        return zalopayOrder;
    }

    public async Task<ZPCreateOrderResponse?> CreateOrderAsync(ZPCreateOrderRequest zaloPayOrder)
    {
        var url = ZalopayBaseUrl + CreateOrderUrl;
        var result = await PostMethodAsync<ZPCreateOrderResponse>(url, zaloPayOrder);
        return result;
    }

    public async Task<ZPQueryOrderResponse?> QueryOrderAsync(string appTransId)
    {
        var data = $"{_zaloPayConfig.AppId}|{appTransId}|{_zaloPayConfig.Key1}";
        var mac = HmacHelper.Compute(_zaloPayConfig.Key1, data);
        var orderQuery = new ZPQueryOrderRequest{ AppId = _zaloPayConfig.AppId, AppTransId = appTransId, Mac = mac };
        return await PostMethodAsync<ZPQueryOrderResponse>(ZalopayBaseUrl + QueryOrderUrl, orderQuery);
    }

    public bool ValidateCallback(ZPCallbackOrderResponse callbackOrder)
    {
        var mac = HmacHelper.Compute(_zaloPayConfig.Key2, callbackOrder.Data);
        return mac.Equals(callbackOrder.Mac);        
    }    

    private async Task<T?> PostMethodAsync<T>(string url, IBaseFormRequest form)
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

    public async Task<ZPQueryUserResponse?> QueryZalopayUserAsync(UserQueryModel model)
    {
        var appTime = CurrentTime.GetTimeStamp();
        var data = $"{_zaloPayConfig.AppId}|{model.Phone}|{appTime}";
        var mac = HmacHelper.Compute(_zaloPayConfig.Key1, data);
        var requestModel = new ZPQueryUserRequest
        {
            AppId = _zaloPayConfig.AppId,
            Phone = model.Phone,
            Time = appTime,
            Mac = mac
        };
        var url = ZalopayBaseUrl + QueryUserUrl;
        var result = await PostMethodAsync<ZPQueryUserResponse>(url, requestModel);
        return result;
    }
}
