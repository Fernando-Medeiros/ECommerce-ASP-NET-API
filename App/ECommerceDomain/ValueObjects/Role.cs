using ECommerceDomain.Abstractions;
using ECommerceDomain.Enums;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed class Role : ValueObject<string?>
{
    public override ValueObject<string?> Validate(string? role)
    {
        if (Required && Enum.TryParse<ERoles>(role ?? "", out _) is false)
        {
            throw new RoleTypeException().SetTarget(nameof(Role));
        }
        return this;
    }
}
