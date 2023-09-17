using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed record UUID : ValueObject<string?>
{
    public UUID(string? data, bool required = true) : base(data, required) { }

    public override void Validate(string? id)
    {
        if (Guid.TryParse(id, out _) is false)
        {
            throw new UUIDFormatException().SetTarget(nameof(UUID));
        }
    }
}
