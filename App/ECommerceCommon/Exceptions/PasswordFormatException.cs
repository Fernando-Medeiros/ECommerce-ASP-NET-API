using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class PasswordFormatException : CustomException
{
    public PasswordFormatException()
        : base(
            status: 400,
            error: nameof(PasswordFormatException),
            message: "Invalid, password format",
            details: new() {
                "options: [a-z A-Z 0-9 ç Ç @ . _ -]",
                "min:8 max:16}"})
    { }
}
