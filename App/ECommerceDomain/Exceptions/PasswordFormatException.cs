using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class PasswordFormatException : DomainException
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
