namespace ECommerceDomain.DTOs;

public record ResponseExceptionDTO(
    int StatusCode,
    string Error,
    string Message,
    List<string> Details,
    DateTime OccurredAt,
    string? Target = null);
