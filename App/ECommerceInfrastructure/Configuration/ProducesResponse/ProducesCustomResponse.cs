using ECommerceCommon;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInfrastructure.Configuration.ProducesResponse;

public abstract class ProducesCustomResponse(
    int statusCode,
    Type? type = null)
    : ProducesResponseTypeAttribute(
        type ?? typeof(CustomExceptionResponse),
        statusCode);

public sealed class Success(Type type) : ProducesCustomResponse(200, type);
public sealed class Created(Type? type = null) : ProducesCustomResponse(201, type);
public sealed class NoContent() : ProducesCustomResponse(204);
public sealed class BadRequest() : ProducesCustomResponse(400);
public sealed class Unauthorized() : ProducesCustomResponse(401);
public sealed class Forbidden() : ProducesCustomResponse(403);
public sealed class NotFound() : ProducesCustomResponse(404);
public sealed class InternalError() : ProducesCustomResponse(500);
