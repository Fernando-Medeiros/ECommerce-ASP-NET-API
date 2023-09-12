namespace ECommerce.Exceptions;

public class ForbiddenError : HttpException
{
    public ForbiddenError(string message)
        : base(403, new ExceptionResponse(message, 403)) { }
}
