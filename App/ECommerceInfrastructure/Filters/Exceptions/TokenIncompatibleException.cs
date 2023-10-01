using ECommerceDomain.Abstractions;
using ECommerceInfrastructure.Authentication.Identities.Claims;
using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Filters.Exceptions;

public sealed class TokenIncompatibleException : DomainException
{
    public TokenIncompatibleException()
        : base(
            status: 403,
            error: nameof(TokenIncompatibleException),
            message: "Access denied, token incompatible",
            details: new() {
                $"properties: {string.Join(", ", ClaimsTypes.Id, ClaimsTypes.Scope, nameof(ClaimsTypes.Role))}",
                $"token types: {string.Join(", ", Enum.GetNames<ETokenType>())}",
                $"token scopes: {string.Join(", ", Enum.GetNames<ETokenScope>())}"
            })
    { }
}
