using ECommerce.Setup.ApiProducesResponse;

namespace ECommerce.Exceptions;

public class NotFoundError : HttpResponseException
{
    public NotFoundError(string message)
        : base(404, new ExceptionResponse(message, 404)) { }
}
