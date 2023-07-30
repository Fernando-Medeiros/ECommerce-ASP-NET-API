namespace ECommerce_ASP_NET_API.Exceptions;

public class BadRequestError : HttpResponseException
{
    public BadRequestError(string? message) : base(400, new { message }) { }
}
