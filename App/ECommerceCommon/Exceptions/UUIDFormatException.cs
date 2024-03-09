namespace ECommerceCommon.Exceptions;

public sealed class UUIDFormatException() : CustomException(
    code: 500,
    error: nameof(UUIDFormatException),
    message: "Invalid UUID format",
    details: [
        "min:36 max:36",
        $"example: {Guid.NewGuid()}",
        ]
    )
{ }