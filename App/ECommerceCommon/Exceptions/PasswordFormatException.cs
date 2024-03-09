namespace ECommerceCommon.Exceptions;

public sealed class PasswordFormatException() : CustomException(
    code: 400,
    error: nameof(PasswordFormatException),
    message: "Invalid, password format",
    details: [
        "options: [a-z A-Z 0-9 ç Ç @ . _ -]",
        "min:8 max:16",
        ]
    )
{ }
