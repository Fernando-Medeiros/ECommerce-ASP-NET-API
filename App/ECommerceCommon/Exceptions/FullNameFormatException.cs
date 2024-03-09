namespace ECommerceCommon.Exceptions;

public sealed class FullNameFormatException() : CustomException(
    code: 400,
    error: nameof(FullNameFormatException),
    message: "Invalid full name format",
    details: [
        "Name, first name and last name must be different",
        ]
    )
{ }