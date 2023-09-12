namespace ECommerce.Exceptions;

public class UnauthorizedError : HttpException
{
    public UnauthorizedError(string message)
        : base(401, new ExceptionResponse(message, 401)) { }
}
