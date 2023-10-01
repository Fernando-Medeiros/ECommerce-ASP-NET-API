using ECommerceDomain.Abstractions;
using ECommerceDomain.Enums;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed record Role : ValueObject<string?>
{
    public Role(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? role)
    {
        if (Enum.TryParse<ERoles>($"{role}", out _) is false)
        {
            throw new RoleTypeException().Target(nameof(Role));
        }
    }
}
