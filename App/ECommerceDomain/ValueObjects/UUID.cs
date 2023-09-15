using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed class UUID : ValueObject<string?>
{
    public override ValueObject<string?> Validate(string? id)
    {
        if (Required && Guid.TryParse(id, out _) is false)
        {
            throw new UUIDFormatException().SetTarget(nameof(UUID));
        }
        return this;
    }
}
