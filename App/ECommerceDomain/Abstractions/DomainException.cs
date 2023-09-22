using ECommerceDomain.DTOs;

namespace ECommerceDomain.Abstractions;

public abstract class DomainException : Exception
{
    public DomainResponseExceptionDTO Value { get; private set; }

    public DomainException(
        int status,
        string error,
        string message,
        List<string> details) : base(message)
    {
        Value = new()
        {
            StatusCode = status,
            Error = error,
            Details = details,
            Message = message,
            OccurredAt = DateTimeOffset.UtcNow,
        };
    }

    public DomainException Target(string? target)
    {
        Value.Target = target;
        return this;
    }
}
