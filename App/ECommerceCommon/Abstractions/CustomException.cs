using ECommerceCommon.DTOs;

namespace ECommerceCommon.Abstractions;

public abstract class CustomException : Exception
{
    public CustomExceptionResponse Value { get; private set; }

    public CustomException(
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

    public CustomException Target(string target)
    {
        Value = Value with { Target = target };
        return this;
    }
}
