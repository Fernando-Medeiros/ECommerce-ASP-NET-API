using System.Security.Claims;
using ECommerceInfrastructure.Auth.Tokens.Enums;
using ECommerceInfrastructure.ExceptionFilter.Exceptions;

namespace ECommerceInfrastructure.Auth.Identities;

public abstract class BaseIdentity
{
    private protected static Claim ExtractProperty(
        string keySelector,
        ClaimsPrincipal principal)
    {
        return principal.Claims.SingleOrDefault(c => c.Type.Equals(keySelector))

                ?? throw new TokenIncompatibleException().Target("Token Properties");
    }

    private protected static void CheckTokenScope(
        string scope,
        List<ETokenScope> scopes)
    {
        if (scopes.Contains(Enum.Parse<ETokenScope>(scope)) is false)

            throw new TokenIncompatibleException().Target("Token Scope");
    }
}