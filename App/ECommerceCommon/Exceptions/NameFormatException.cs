namespace ECommerceCommon.Exceptions;

public sealed class NameFormatException() : CustomException(
    code: 400,
    error: nameof(NameFormatException),
    message: "Invalid name format",
    details: [
        "min:3 max:18",
        "options [A-Z a-z À-ÿ]",
        ]
    )
{ }