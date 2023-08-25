using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Startup.SwaggerProducesResponse;

public class ProducesCustomResponse : ProducesResponseTypeAttribute
{
    public ProducesCustomResponse(
        int statusCode, Type? type = null)
        : base(type ?? typeof(ExceptionResponse), statusCode) { }
}

public class Success : ProducesCustomResponse
{ public Success(Type type) : base(200, type) { } }

public class Created : ProducesCustomResponse
{ public Created(Type type) : base(201, type) { } }

public class NoContent : ProducesCustomResponse
{ public NoContent() : base(204, typeof(Nullable)) { } }

public class BadRequest : ProducesCustomResponse
{ public BadRequest() : base(400) { } }

public class Unauthorized : ProducesCustomResponse
{ public Unauthorized() : base(401) { } }

public class Forbidden : ProducesCustomResponse
{ public Forbidden() : base(403) { } }

public class NotFound : ProducesCustomResponse
{ public NotFound() : base(404) { } }

public class InternalError : ProducesCustomResponse
{ public InternalError() : base(500) { } }
