using ECommerceCommon;
using ECommerceInfrastructure.Auth.Identities.Claims;
using ECommerceInfrastructure.Auth.Tokens.Enums;

namespace ECommerceInfrastructure.ExceptionFilter.Exceptions;

public sealed class TokenIncompatibleException() : CustomException(
    code: 403,
    error: nameof(TokenIncompatibleException),
    message: "Access denied, token incompatible",
    details: [
        $"properties: {string.Join(", ", ClaimType.Id, ClaimType.Scope, nameof(ClaimType.Role))}",
        $"token types: {string.Join(", ", Enum.GetNames<ETokenType>())}",
        $"token scopes: {string.Join(", ", Enum.GetNames<ETokenScope>())}",
        ]
    )
{ }
