using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FondApi.Host.Extenstions.ExceptionMiddleware;

public class ErrorDetails
{
    public ErrorDetails(int statusCode, string? message, string? error = null)
    {
        StatusCode = statusCode;
        Message = message;
        Error = error;
    }

    public int StatusCode { get; init; }

    public string? Message { get; init; }

    public string? Error { get; init; }

    public override string ToString() => JsonConvert.SerializeObject(this, new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy(),
        },
    });
}
