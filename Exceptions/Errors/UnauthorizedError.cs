namespace ECommerce_ASP_NET_API.Exceptions;

public class UnauthorizedError : HttpResponseException
{
    public UnauthorizedError(string? message) : base(401, new { message }) { }
}
