using System.Security.Claims;

namespace ECommerceInfrastructure.Authentication.Identities.Claims;

public static class ClaimsTypes
{
    public const string Id = "id";
    public const string Scope = "scope";
    public const string Role = ClaimTypes.Role;
}
