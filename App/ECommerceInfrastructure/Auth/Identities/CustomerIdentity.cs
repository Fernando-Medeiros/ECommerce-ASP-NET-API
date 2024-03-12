using ECommerceDomain.Enums;
using ECommerceInfrastructure.Auth.Identities.Claims;
using System.Security.Claims;

namespace ECommerceInfrastructure.Auth.Identities;

public sealed class CustomerIdentity : BaseIdentity
{
    public readonly string Id;
    public readonly string Scope;

    public CustomerIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(ClaimType.Id, principal).Value;
        Scope = ExtractProperty(ClaimType.Scope, principal).Value;

        CheckTokenScope(Scope, [ETokenScope.Access, ETokenScope.Refresh]);
    }

    public CustomerIdentity(ClaimsPrincipal principal, List<ETokenScope> scopes)
    {
        Id = ExtractProperty(ClaimType.Id, principal).Value;
        Scope = ExtractProperty(ClaimType.Scope, principal).Value;

        CheckTokenScope(Scope, scopes);
    }
}