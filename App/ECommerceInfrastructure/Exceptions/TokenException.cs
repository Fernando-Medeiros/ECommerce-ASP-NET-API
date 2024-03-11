using ECommerceCommon;
using ECommerceInfrastructure.Auth.Identities.Claims;
using ECommerceInfrastructure.Auth.Tokens.Enums;

namespace ECommerceInfrastructure.Exceptions;

public sealed class TokenException() : CustomException(
    code: 403,
    error: nameof(TokenException),
    message: "Access denied, token incompatible",
    details: [
        $"properties: {string.Join(", ", ClaimType.Id, ClaimType.Scope, nameof(ClaimType.Role))}",
        $"token types: {string.Join(", ", Enum.GetNames<ETokenType>())}",
        $"token scopes: {string.Join(", ", Enum.GetNames<ETokenScope>())}",
        ]
    )
{ }
