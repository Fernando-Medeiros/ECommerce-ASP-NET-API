namespace ECommerce_ASP_NET_API.Exceptions;

public class NotFoundError : HttpResponseException
{
    public NotFoundError(string? message) : base(404, new { message }) { }
}
