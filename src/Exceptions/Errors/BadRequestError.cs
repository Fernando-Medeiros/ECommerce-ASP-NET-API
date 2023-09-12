namespace ECommerce.Exceptions;

public class BadRequestError : HttpException
{
    public BadRequestError(string message)
        : base(400, new ExceptionResponse(message, 400)) { }
}
