using System.Security.Claims;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Identities;

public class CustomerIdentity : MainIdentity
{
    public readonly string Id;
    public readonly string Scope;

    public CustomerIdentity(ClaimsPrincipal principal)
    {
        Id = ExtractProperty(ClaimsTypes.Id, principal).Value;
        Scope = ExtractProperty(ClaimsTypes.Scope, principal).Value;

        CheckTokenScope(Scope, new() { ETokenScope.Access, ETokenScope.Refresh });
    }

    public CustomerIdentity(ClaimsPrincipal principal, List<ETokenScope> scopes)
    {
        Id = ExtractProperty(ClaimsTypes.Id, principal).Value;
        Scope = ExtractProperty(ClaimsTypes.Scope, principal).Value;

        CheckTokenScope(Scope, scopes);
    }
}
