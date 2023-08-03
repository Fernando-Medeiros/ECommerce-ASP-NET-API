namespace ECommerce.Exceptions;

public class BadRequestError : HttpResponseException
{
    public BadRequestError(string? message) : base(400, new { message }) { }
}
