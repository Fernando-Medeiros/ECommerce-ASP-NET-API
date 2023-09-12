using ECommerce.Setup.ApiProducesResponse;

namespace ECommerce.Exceptions;

public class UnauthorizedError : HttpResponseException
{
    public UnauthorizedError(string message)
        : base(401, new ExceptionResponse(message, 401)) { }
}
