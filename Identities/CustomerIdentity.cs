namespace ECommerce.Identities;

using System.Security.Claims;
using ECommerce.Exceptions;

public class CustomerIdentity
{
    public readonly string Id;

    public CustomerIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(principal, "id").Value;
    }

    private static Claim ExtractProperty(ClaimsPrincipal principal, string keySelector)
    {
        return principal.Claims
            .SingleOrDefault(c => c.Type.Equals(keySelector))
            ?? throw new ForbiddenError("Access denied, token incompatible");
    }

}
