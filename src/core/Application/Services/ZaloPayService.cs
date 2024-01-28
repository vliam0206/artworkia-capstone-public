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
    private const string BaseUrl = "https://sb-openapi.zalopay.vn/v2";
    private const string CreateOrderUrl = "/create";
    private const string QueryOrderUrl = "/query";
    private readonly AppConfiguration _appConfiguration;
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public ZaloPayService(AppConfiguration appConfiguration, IMapper mapper)
    {
        _appConfiguration = appConfiguration;
        _httpClient = new HttpClient();
        _mapper = mapper;
    }

    public ZaloPayOrderCreate BuildZaloPayOrderCreate(OrderCreateModel model)
    {
        var appId = _appConfiguration.ZaloPayConfiguration.AppId;
        var appUSer = _appConfiguration.ZaloPayConfiguration.AppUser;
        var appTime = CurrentTime.GetTimeStamp();
        var key1 = _appConfiguration.ZaloPayConfiguration.Key1;
        var rnd = new Random();
        var appTransId = CurrentTime.GetCurrentTime.ToString("yyMMdd") + "_" + rnd.Next(1000000);        
        var data = $"{appId}|{appTransId}|{appUSer}|{model.Amount}|{appTime}|{model.EmbedData}|{model.Item}";        
        
        var zalopayOrder = _mapper.Map<ZaloPayOrderCreate>(model);
        zalopayOrder.AppId = appId;
        zalopayOrder.AppUser= appUSer;
        zalopayOrder.AppTransId = appTransId;
        zalopayOrder.AppTime = appTime;
        zalopayOrder.Description = "Nap xu nen tang Artworkia.";
        zalopayOrder.Mac = HmacHelper.Compute(key1, data);

        return zalopayOrder;
    }

    public async Task<ZaloPayOrderResult?> CreateOrder(ZaloPayOrderCreate zaloPayOrder)
    {
        var url = BaseUrl + CreateOrderUrl;
        var result = await PostMethod<ZaloPayOrderResult>(url, zaloPayOrder);
        return result;
    }

    public Task<ZaloPayOrderQueryResult?> QueryOrder(string appTransId)
    {
        throw new NotImplementedException();
    }

    public bool ValidateCallback(ZaloPayCallbackOrder callbackOrder)
    {
        throw new NotImplementedException();
    }

    public bool ValidateRedirect(ZaloPayRedirectOrder redirectOrder)
    {
        throw new NotImplementedException();
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
