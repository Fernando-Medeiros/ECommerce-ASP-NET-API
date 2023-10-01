using System.Security.Claims;
using ECommerceInfrastructure.Authentication.Tokens.Enums;
using ECommerceInfrastructure.Filters.Exceptions;

namespace ECommerceInfrastructure.Authentication.Identities;

public abstract class Identity
{
    private protected static Claim ExtractProperty(
        string keySelector,
        ClaimsPrincipal principal)
    {
        return principal.Claims
            .SingleOrDefault(c => c.Type.Equals(keySelector))
                ?? throw new TokenIncompatibleException()
                    .Target("Token Properties");

    }

    private protected static void CheckTokenScope(
        string scope,
        List<ETokenScopes> scopes)
    {
        if (scopes.Contains(Enum.Parse<ETokenScopes>(scope)) is false)
            throw new TokenIncompatibleException()
                .Target("Token Scope");
    }
}