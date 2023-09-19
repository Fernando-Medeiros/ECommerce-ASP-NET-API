using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class FullNameFormatException : DomainException
{
    public FullNameFormatException()
        : base(
            status: 404,
            error: nameof(FullNameFormatException),
            message: "Invalid full name format",
            details: new() { "Name, first name and last name must be different" })
    { }
}