using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Application.Commons;

public class JsonConvertHelper<T> where T : class
{
    public static T? ConvertSnakeJsonToObject(string jsonString)
    {
        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
        var result = JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
        {
            ContractResolver = contractResolver,
            Formatting = Formatting.Indented
        });
        return result;
    }
}