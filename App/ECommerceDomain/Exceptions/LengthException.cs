using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class LengthException : DomainException
{
    public LengthException(string? target, int min, int max)
        : base(
            status: 400,
            error: nameof(LengthException),
            message: $"The {target} must be between {min} and {max} characters",
            details: new() { $"min: {min}, max: {max}" })
    { }
}

