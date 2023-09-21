using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class EmailFormatException : DomainException
{
    public EmailFormatException()
        : base(
            status: 400,
            error: nameof(EmailFormatException),
            message: "Invalid email format",
            details: new() {
                "min:6 max:*",
                "options: [a-z A-Z 0-9 . _ % + -]",
                "example: e@e.co"})
    { }
}
