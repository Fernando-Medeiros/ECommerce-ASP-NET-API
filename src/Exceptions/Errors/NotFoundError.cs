using ECommerce.Startup.SwaggerProducesResponse;

namespace ECommerce.Exceptions;

public class NotFoundError : HttpResponseException
{
    public NotFoundError(string message)
        : base(404, new ExceptionResponse(message, 404)) { }
}
