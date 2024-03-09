using System.Security.Claims;

namespace ECommerceInfrastructure.Auth.Identities.Claims;

public static class ClaimType
{
    public const string Id = "id";
    public const string Scope = "scope";
    public const string Role = ClaimTypes.Role;
}
