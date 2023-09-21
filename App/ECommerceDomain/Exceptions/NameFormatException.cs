using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class NameFormatException : DomainException
{
    public NameFormatException()
        : base(
            status: 400,
            error: nameof(NameFormatException),
            message: "Invalid name format",
            details: new() {
                "min:3 max:18",
                "options [A-Z a-z À-ÿ]"})
    { }
}