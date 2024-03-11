using System.Text;
using ECommerceDomain.DTO;
using ECommerceInfrastructure.Auth.Tokens;
using ECommerceInfrastructure.Auth.Tokens.Enums;
using Newtonsoft.Json;

namespace TestSetup.Fixtures;

public sealed class RequestFixture(
    string url,
    string? mediaType = "application/json")
{
    public string URL { get; init; } = url;
    public string MediaType { get; init; } = mediaType!;
    public StringContent? Payload { get; private set; }
    public List<Tuple<string, string>> Headers { get; private set; } = [];

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

        string token = tokenService.Generate(customer, ETokenScope.Access).Value;

        Headers.Add(new("Authorization", $"Bearer {token}"));
        return this;
    }
}
