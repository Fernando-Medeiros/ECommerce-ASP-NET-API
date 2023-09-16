using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Authentication.Tokens.DTOs;

public readonly struct TokenDTO
{
    public readonly string Token { get; init; }
    public readonly ETokenTypes Type { get; init; }
    public readonly ETokenScopes Scope { get; init; }

    public TokenDTO(
        string token,
        ETokenTypes type,
        ETokenScopes scope)
    {
        Token = token;
        Type = type;
        Scope = scope;
    }
}
