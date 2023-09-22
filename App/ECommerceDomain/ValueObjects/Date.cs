using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed record Date : ValueObject<DateTimeOffset?>
{
    public Date(DateTimeOffset? data, bool required = true) : base(data, required) { }

    public override void Validate(DateTimeOffset? data)
    {
        if (data == null || DateTimeOffset.TryParse($"{data.Value}", out _) is false)
        {
            throw new DateFormatException().Target(nameof(DateTimeOffset));
        }
    }
}
