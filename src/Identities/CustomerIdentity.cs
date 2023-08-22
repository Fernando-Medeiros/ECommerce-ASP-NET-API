using System.Security.Claims;
using ECommerce.Exceptions;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Identities;

public class CustomerIdentity
{
    public readonly string Id;
    public readonly string Scope;

    public CustomerIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(principal, "id").Value;

        Scope = ExtractProperty(principal, "scope").Value;

        CheckTokenScope();
    }

    private protected static Claim ExtractProperty(
        ClaimsPrincipal principal, string keySelector)
    {
        return principal.Claims
            .SingleOrDefault(c => c.Type.Equals(keySelector))
            ?? throw new ForbiddenError("Access denied, token incompatible");
    }

    private protected void CheckTokenScope()
    {
        if (Scope != Enum.GetName(ETokenScope.Access) ||
            Scope != Enum.GetName(ETokenScope.Refresh))
            throw new UnauthorizedError("Access denied, token scope incompatible");
    }
}
