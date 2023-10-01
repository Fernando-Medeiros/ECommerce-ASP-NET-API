using ECommerceDomain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInfrastructure.Configuration.ProducesResponse;

public abstract class ProducesCustomResponse : ProducesResponseTypeAttribute
{
    public ProducesCustomResponse(
        int statusCode, Type? type = null)
        : base(type ?? typeof(ResponseExceptionDTO), statusCode) { }
}

public sealed class Success : ProducesCustomResponse
{ public Success(Type type) : base(200, type) { } }


public sealed class Created : ProducesCustomResponse
{ public Created(Type? type = null) : base(201, type) { } }


public sealed class NoContent : ProducesCustomResponse
{ public NoContent() : base(204) { } }


public sealed class BadRequest : ProducesCustomResponse
{ public BadRequest() : base(400) { } }


public sealed class Unauthorized : ProducesCustomResponse
{ public Unauthorized() : base(401) { } }


public sealed class Forbidden : ProducesCustomResponse
{ public Forbidden() : base(403) { } }


public sealed class NotFound : ProducesCustomResponse
{ public NotFound() : base(404) { } }


public class InternalError : ProducesCustomResponse
{ public InternalError() : base(500) { } }
