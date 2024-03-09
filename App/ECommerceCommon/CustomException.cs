namespace ECommerceCommon;

public abstract class CustomException(
    int code,
    string error,
    string message,
    List<string> details) : Exception(message)
{
    public CustomExceptionResponse Value { get; private set; } = new(
            Error: error,
            StatusCode: code,
            Details: details,
            Message: message,
            OccurredAt: DateTime.UtcNow
        );

    public CustomException Target(string target)
    {
        Value = Value with { Target = target };
        return this;
    }
}
