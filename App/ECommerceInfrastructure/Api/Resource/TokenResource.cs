using ECommerceInfrastructure.Auth.Tokens;

namespace ECommerceInfrastructure.Api.Resource;

public readonly struct TokenResource(Token x)
{
    public string Token { get; } = x.Value;
    public string Type { get; } = Enum.GetName(x.Type)!;
    public string Scope { get; } = Enum.GetName(x.Scope)!;
}