using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class NotNullException : DomainException
{
    public NotNullException(string? target)
        : base(
            status: 400,
            error: nameof(NotNullException),
            message: $"The {target} is Required",
            details: new() { $"The {target} cannot be null" })
    { }
}

