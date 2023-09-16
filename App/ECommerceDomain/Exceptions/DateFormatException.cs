using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class DateFormatException : DomainException
{
    public DateFormatException()
        : base(
            status: 500,
            error: nameof(DateFormatException),
            message: "Invalid date time format",
            details: new() {
                $"example: {DateTimeOffset.UtcNow}"})
    { }
}
