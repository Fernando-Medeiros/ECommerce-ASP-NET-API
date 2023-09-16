using System.Security.Claims;
using ECommerceInfrastructure.Authentication.Identities.Claims;
using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Authentication.Identities;

public sealed class CustomerIdentity : Identity
{
    public readonly string Id;
    public readonly string Scope;

    public CustomerIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(ClaimsTypes.Id, principal).Value;
        Scope = ExtractProperty(ClaimsTypes.Scope, principal).Value;

        CheckTokenScope(Scope, new() { ETokenScopes.Access, ETokenScopes.Refresh });
    }

    public CustomerIdentity(ClaimsPrincipal principal, List<ETokenScopes> scopes)
    {
        Id = ExtractProperty(ClaimsTypes.Id, principal).Value;
        Scope = ExtractProperty(ClaimsTypes.Scope, principal).Value;

        CheckTokenScope(Scope, scopes);
    }
}