using ECommerceCommon.Exceptions;
using ECommerceDomain.Abstraction;

namespace ECommerceDomain.ValueObjects;

public sealed record Code : ValueObject<string?>
{
    public Code(string? value, bool required = true) : base(value, required) { }

    protected override void Validate(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new AddressException().Target(nameof(Code));
        }
    }
}
