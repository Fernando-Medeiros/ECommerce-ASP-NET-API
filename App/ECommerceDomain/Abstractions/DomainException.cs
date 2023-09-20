namespace ECommerceDomain.Abstractions;

public abstract class DomainException : Exception
{
    public DomainResponseException Value { get; private set; } = new();

    public DomainException(
        int status,
        string error,
        string message,
        List<string> details) : base(message)
    {
        Value.StatusCode = status;
        Value.Error = error;
        Value.Details = details;
        Value.Message = message;
        Value.StatusCode = status;
        Value.OccurredAt = DateTimeOffset.UtcNow;
    }

    public DomainException Target(string? target)
    {
        Value.Target = target;
        return this;
    }
}
