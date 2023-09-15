namespace ECommerceDomain.Abstractions;

public abstract class DomainException : Exception
{
    public int StatusCode { get; private set; }
    public string? Error { get; private set; }
    public string? Target { get; private set; }
    public List<string> Details { get; private set; }
    public DateTimeOffset? OccurredAt { get; private set; }

    public DomainException(
        int status,
        string error,
        string message,
        List<string> details) : base(message)
    {
        Error = error;
        Details = details;
        StatusCode = status;
        OccurredAt = DateTimeOffset.UtcNow;
    }

    public DomainException SetTarget(string? target)
    {
        Target = target;
        return this;
    }
}
