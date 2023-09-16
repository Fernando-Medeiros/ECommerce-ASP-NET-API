using ECommerceDomain.Abstractions;
using ECommerceInfrastructure.Authentication.Identities.Claims;
using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Interceptor.Exceptions;

public sealed class JwtTokenIncompatibleException : DomainException
{
    public JwtTokenIncompatibleException()
        : base(
            status: 403,
            error: nameof(JwtTokenIncompatibleException),
            message: "Access denied, token incompatible",
            details: new() {
                $"properties: {string.Join(", ", ClaimsTypes.Id, ClaimsTypes.Scope, nameof(ClaimsTypes.Role))}",
                $"token types: {string.Join(", ", Enum.GetNames<ETokenTypes>())}",
                $"token scopes: {string.Join(", ", Enum.GetNames<ETokenScopes>())}"
            })
    { }
}
