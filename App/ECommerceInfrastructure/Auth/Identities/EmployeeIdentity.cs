using ECommerceDomain.Enums;
using ECommerceInfrastructure.Auth.Identities.Claims;
using System.Security.Claims;

namespace ECommerceInfrastructure.Auth.Identities;

public sealed class EmployeeIdentity : BaseIdentity
{
    public readonly string Id;
    public readonly string Role;
    public readonly string Scope;

    public EmployeeIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(ClaimType.Id, principal).Value;
        Role = ExtractProperty(ClaimType.Role, principal).Value;
        Scope = ExtractProperty(ClaimType.Scope, principal).Value;

        CheckTokenScope(Scope, [ETokenScope.Access, ETokenScope.Refresh]);
    }
}