namespace ECommerce.Exceptions;

public abstract class HttpResponseException : Exception
{
    public int Status { get; }

    public object? Value { get; }

    public HttpResponseException(
        int statusCode,
        object? value = null)
    {
        Status = statusCode;
        Value = value;
    }
}
