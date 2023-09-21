using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class NotEmptyException : DomainException
{
    public NotEmptyException(string? target)
        : base(
            status: 400,
            error: nameof(NotEmptyException),
            message: $"The {target} is Required",
            details: new() { $"The {target} cannot be empty" })
    { }
}

