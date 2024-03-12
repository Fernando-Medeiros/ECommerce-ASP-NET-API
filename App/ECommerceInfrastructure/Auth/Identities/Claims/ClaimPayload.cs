using System.Security.Claims;
using ECommerceDomain.DTO;
using ECommerceDomain.Enums;

namespace ECommerceInfrastructure.Auth.Identities.Claims;

public sealed class ClaimPayload : ClaimsIdentity
{
    public ClaimPayload(CustomerDTO customer, ETokenScope tokenScope)
    {
        AddClaim(new(ClaimType.Id, customer.Id!));

        AddClaim(new(ClaimType.Scope, Enum.GetName(tokenScope)!));

        AddClaim(new(ClaimType.Role, customer.Role!));
    }
}