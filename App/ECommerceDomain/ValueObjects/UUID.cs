using ECommerceCommon.Exceptions;
using ECommerceDomain.Abstraction;

namespace ECommerceDomain.ValueObjects;

public sealed record UUID : ValueObject<string?>
{
    public UUID(string? data, bool required = true) : base(data, required) { }

    protected override void Validate(string? id)
    {
        if (Guid.TryParse(id, out _) is false)
        {
            throw new UUIDFormatException().Target(nameof(UUID));
        }
    }
}
