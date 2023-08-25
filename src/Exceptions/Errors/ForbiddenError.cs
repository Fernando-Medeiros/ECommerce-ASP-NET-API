using ECommerce.Startup.SwaggerProducesResponse;

namespace ECommerce.Exceptions;

public class ForbiddenError : HttpResponseException
{
    public ForbiddenError(string message)
        : base(403, new ExceptionResponse(message, 403)) { }
}
