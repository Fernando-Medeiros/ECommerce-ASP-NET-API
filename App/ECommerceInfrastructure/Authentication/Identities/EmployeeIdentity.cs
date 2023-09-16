using System.Security.Claims;
using ECommerceInfrastructure.Authentication.Identities.Claims;
using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Authentication.Identities;

public sealed class EmployeeIdentity : Identity
{
    public readonly string Id;
    public readonly string Role;
    public readonly string Scope;

    public EmployeeIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(ClaimsTypes.Id, principal).Value;
        Role = ExtractProperty(ClaimsTypes.Role, principal).Value;
        Scope = ExtractProperty(ClaimsTypes.Scope, principal).Value;

        CheckTokenScope(Scope, new() { ETokenScopes.Access, ETokenScopes.Refresh });
    }
}