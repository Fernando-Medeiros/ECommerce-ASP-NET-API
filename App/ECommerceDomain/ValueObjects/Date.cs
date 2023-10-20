using ECommerceCommon.Exceptions;
using ECommerceDomain.Abstractions;

namespace ECommerceDomain.ValueObjects;

public sealed record Date : ValueObject<DateTimeOffset?>
{
    public Date(DateTimeOffset? data, bool required = true) : base(data, required) { }

    public override void Validate(DateTimeOffset? date)
    {
        if (date is null || DateTimeOffset.TryParse($"{date.Value}", out _) is false)
        {
            throw new DateFormatException().Target(nameof(DateTimeOffset));
        }
    }
}
