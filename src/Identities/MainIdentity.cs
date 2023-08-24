using System.Security.Claims;
using ECommerce.Exceptions;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Identities;

public abstract class MainIdentity
{
    private protected static Claim ExtractProperty(
        string keySelector,
        ClaimsPrincipal principal)
    {
        return principal.Claims
            .SingleOrDefault(c => c.Type.Equals(keySelector))
                ?? throw new ForbiddenError(
                    "Access denied, token incompatible");
    }

    private protected static void CheckTokenScope(
        string scope,
        List<ETokenScope> scopes)
    {
        if (scopes.Contains(Enum.Parse<ETokenScope>(scope)) is false)
            throw new ForbiddenError(
                "Access denied, token scope incompatible");
    }
}
