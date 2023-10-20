using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class DateFormatException : CustomException
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
