using ECommerceDomain.DTO;

namespace ECommerceAPI.Resource;

public readonly struct TokenResource(TokenDTO x)
{
    public string Token { get; init; } = x.Value;
    public string Type { get; init; } = Enum.GetName(x.Type)!;
    public string Scope { get; init; } = Enum.GetName(x.Scope)!;
}