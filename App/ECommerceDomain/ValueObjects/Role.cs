using ECommerceCommon.Exceptions;
using ECommerceDomain.Abstraction;
using ECommerceDomain.Enums;

namespace ECommerceDomain.ValueObjects;

public sealed record Role : ValueObject<string?>
{
    public Role(string? data, bool required = true) : base(data, required) { }

    protected override void Validate(string? role)
    {
        if (Enum.TryParse<ERole>($"{role}", out _) is false)
        {
            throw new RoleTypeException().Target(nameof(Role));
        }
    }
}
