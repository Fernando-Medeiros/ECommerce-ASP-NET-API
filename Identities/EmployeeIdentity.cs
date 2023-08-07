namespace ECommerce.Identities;

using System.Security.Claims;

public class EmployeeIdentity : CustomerIdentity
{
    public readonly string Role;

    public EmployeeIdentity(ClaimsPrincipal principal) : base(principal)
    {
        Role = ExtractProperty(principal, ClaimTypes.Role).Value;
    }
}
