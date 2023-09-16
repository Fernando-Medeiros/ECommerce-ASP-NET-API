namespace ECommerceDomain.Abstractions;

public class DomainResponseException
{
    public int StatusCode { get; set; }
    public string? Error { get; set; }
    public string? Target { get; set; }
    public string? Message { get; set; }
    public List<string>? Details { get; set; }
    public DateTimeOffset? OccurredAt { get; set; }
}
