using ECommerceInfrastructure.Auth.Tokens;

namespace ECommerceAPI.Resource;

public readonly struct TokenResource(Token x)
{
    public string Token { get; init; } = x.Value;
    public string Type { get; init; } = Enum.GetName(x.Type)!;
    public string Scope { get; init; } = Enum.GetName(x.Scope)!;
}