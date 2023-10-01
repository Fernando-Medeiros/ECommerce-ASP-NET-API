using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Authentication.Tokens.DTOs;

public readonly struct TokenDTO
{
    public readonly string Token { get; init; }
    public readonly ETokenType Type { get; init; }
    public readonly ETokenScope Scope { get; init; }

    public TokenDTO(
        string token,
        ETokenType type,
        ETokenScope scope)
    {
        Token = token;
        Type = type;
        Scope = scope;
    }
}
