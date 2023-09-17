using ECommerceDomain.Abstractions;
using ECommerceDomain.Exceptions;

namespace ECommerceDomain.ValueObjects;

public sealed class Date : ValueObject<DateTimeOffset?>
{
    public Date(DateTimeOffset? data, bool required = true) : base(data, required) { }

    public override void Validate(DateTimeOffset? data)
    {
        if (data == null ||
            DateTimeOffset.TryParse(data.Value.ToString(), out _) is false)
            throw new DateFormatException()
                .SetTarget(nameof(DateTimeOffset));
    }
}
