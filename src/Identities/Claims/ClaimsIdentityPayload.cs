using System.Security.Claims;
using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Identities;

public class ClaimsIdentityPayload : ClaimsIdentity
{
    public ClaimsIdentityPayload(
        CustomerDTO customer, ETokenScope tokenScope)
    {
        this.AddClaim(new Claim(ClaimsTypes.Id, customer.Id!));

        this.AddClaim(new Claim(ClaimsTypes.Scope, Enum.GetName(tokenScope)!));

        this.AddClaim(new Claim(ClaimsTypes.Role, customer.Role ?? ""));
    }
}
