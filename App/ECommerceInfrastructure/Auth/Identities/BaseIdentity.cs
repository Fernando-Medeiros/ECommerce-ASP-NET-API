using ECommerceInfrastructure.Auth.Tokens.Enums;
using ECommerceInfrastructure.Exceptions;
using System.Security.Claims;

namespace ECommerceInfrastructure.Auth.Identities;

public abstract class BaseIdentity
{
    private protected static Claim ExtractProperty(
        string keySelector,
        ClaimsPrincipal principal)
    {
        return principal.Claims.SingleOrDefault(c => c.Type.Equals(keySelector))

                ?? throw new TokenException().Target("Token Properties");
    }

    private protected static void CheckTokenScope(
        string scope,
        List<ETokenScope> scopes)
    {
        if (scopes.Contains(Enum.Parse<ETokenScope>(scope)) is false)

            throw new TokenException().Target("Token Scope");
    }
}