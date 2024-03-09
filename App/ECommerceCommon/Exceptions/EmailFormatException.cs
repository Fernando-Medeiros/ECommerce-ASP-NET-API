namespace ECommerceCommon.Exceptions;

public sealed class EmailFormatException() : CustomException(
    code: 400,
    error: nameof(EmailFormatException),
    message: "Invalid email format",
    details: [
        "min:6 max:*",
        "options: [a-z A-Z 0-9 . _ % + -]",
        "example: e@e.co"
        ])
{ }
