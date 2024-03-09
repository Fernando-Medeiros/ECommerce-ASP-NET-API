namespace ECommerceCommon.Exceptions;

public sealed class DateFormatException() : CustomException(
    code: 500,
    error: nameof(DateFormatException),
    message: "Invalid date time format",
    details: [
        $"example: {DateTimeOffset.UtcNow}",
        ]
    )
{ }
