using ECommerceInfrastructure.Authentication.Tokens.DTOs;

namespace ECommerceInfrastructure.Presentation.Resources;

public readonly struct TokenResource
{
    public string Token { get; init; }
    public string Type { get; init; }
    public string Scope { get; init; }

    public TokenResource(TokenDTO x)
    {
        Token = x.Token;
        Type = Enum.GetName(x.Type)!;
        Scope = Enum.GetName(x.Scope)!;
    }
}