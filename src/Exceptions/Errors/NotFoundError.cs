namespace ECommerce.Exceptions;

public class NotFoundError : HttpException
{
    public NotFoundError(string message)
        : base(404, new ExceptionResponse(message, 404)) { }
}
