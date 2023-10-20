namespace ECommerceCommon.DTOs;

public record CustomExceptionResponse(
    int StatusCode,
    string Error,
    string Message,
    List<string> Details,
    DateTime OccurredAt,
    string? Target = null);
