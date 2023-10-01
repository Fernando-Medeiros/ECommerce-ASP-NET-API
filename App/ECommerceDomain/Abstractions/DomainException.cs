using ECommerceDomain.DTOs;

namespace ECommerceDomain.Abstractions;

public abstract class DomainException : Exception
{
    public ResponseExceptionDTO Value { get; private set; }

    public DomainException(
        int status,
        string error,
        string message,
        List<string> details) : base(message)
    {
        Value = new(
            StatusCode: status,
            Error: error,
            Details: details,
            Message: message,
            OccurredAt: DateTime.UtcNow
        );
    }

    public DomainException Target(string target)
    {
        Value = Value with { Target = target };
        return this;
    }
}
