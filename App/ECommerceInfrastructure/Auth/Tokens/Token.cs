using ECommerceInfrastructure.Auth.Tokens.Enums;

namespace ECommerceInfrastructure.Auth.Tokens;

public record Token(
    string Value,
    ETokenType Type,
    ETokenScope Scope);
