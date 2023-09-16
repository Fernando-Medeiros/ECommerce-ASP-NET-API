using System.Security.Claims;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Authentication.Identities.Claims;

public sealed class ClaimsIdentityPayload : ClaimsIdentity
{
    public ClaimsIdentityPayload(
        CustomerDTO customer, ETokenScopes tokenScope)
    {
        this.AddClaim(new Claim(ClaimsTypes.Id, customer.Id!));

        this.AddClaim(new Claim(ClaimsTypes.Scope, Enum.GetName(tokenScope)!));

        this.AddClaim(new Claim(ClaimsTypes.Role, customer.Role!));
    }
}