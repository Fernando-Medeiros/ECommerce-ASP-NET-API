using ECommerceInfrastructure.Authentication.Tokens;
using ECommerceInfrastructure.Authentication.Tokens.Enums;
using Test.Setup.Mocks;

namespace Test.Setup.Fixtures;

public sealed class RequestFixture
{
    public string URL { get; private init; }

    public List<Tuple<string, string>> Headers { get; private set; } = new();

    public RequestFixture(string url) => URL = url;

    public HttpRequestMessage CreateRequest(HttpMethod method)
    {
        var request = new HttpRequestMessage(method, URL);

        Headers.ForEach((header) =>
        {
            var (key, value) = header;

            request.Headers.Add($"{key}", $"{value}");
        });
        return request;
    }

    public RequestFixture FakeAuthorizationHeader()
    {
        var tokenService = new TokenService();

        string token = tokenService.Generate(
            CustomerMocks.Customer, ETokenScopes.Access).Token;

        Headers.Add(new("Authorization", $"Bearer {token}"));
        return this;
    }
}
