using System.Security.Claims;

namespace ECommerce.Identities;

public static class ClaimsTypes
{
    public const string Id = "id";
    public const string Scope = "scope";
    public const string Role = ClaimTypes.Role;
}
