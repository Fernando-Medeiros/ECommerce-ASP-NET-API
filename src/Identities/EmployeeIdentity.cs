using System.Security.Claims;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Identities;

public class EmployeeIdentity : MainIdentity
{
    public readonly string Id;
    public readonly string Role;
    public readonly string Scope;

    public EmployeeIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty("id", principal).Value;
        Role = ExtractProperty(ClaimTypes.Role, principal).Value;
        Scope = ExtractProperty("scope", principal).Value;

        CheckTokenScope(Scope, new() { ETokenScope.Access, ETokenScope.Refresh });
    }
}
