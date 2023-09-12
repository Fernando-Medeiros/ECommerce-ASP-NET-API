namespace ECommerce.Exceptions;

public abstract class HttpException : Exception
{
    public int Status { get; }

    public object? Value { get; }

    public HttpException(
        int statusCode,
        object? value = null)
    {
        Status = statusCode;
        Value = value;
    }
}
