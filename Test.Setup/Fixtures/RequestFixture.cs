using System.Text;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Authentication.Tokens;
using ECommerceInfrastructure.Authentication.Tokens.Enums;
using Newtonsoft.Json;

namespace Test.Setup.Fixtures;

public sealed class RequestFixture
{
    public string URL { get; init; }
    public string MediaType { get; init; }
    public StringContent? Payload { get; private set; }
    public List<Tuple<string, string>> Headers { get; private set; } = new();

    public RequestFixture(
        string url,
        string? mediaType = "application/json")
    {
        URL = url;
        MediaType = mediaType!;
    }

    public HttpRequestMessage RequestMessage(HttpMethod method)
    {
        var request = new HttpRequestMessage(method, URL)
        {
            Content = Payload
        };

        Headers.ForEach((header) =>
        {
            var (key, value) = header;

            request.Headers.Add($"{key}", $"{value}");
        });
        return request;
    }

    public RequestFixture JsonContent(object obj)
    {
        string json = JsonConvert.SerializeObject(obj);

        Payload = new StringContent(json, Encoding.UTF8, MediaType);
        return this;
    }

    public RequestFixture AuthorizationHeader(CustomerDTO customer)
    {
        var tokenService = new TokenService();

        string token = tokenService.Generate(customer, ETokenScope.Access).Token;

        Headers.Add(new("Authorization", $"Bearer {token}"));
        return this;
    }
}
