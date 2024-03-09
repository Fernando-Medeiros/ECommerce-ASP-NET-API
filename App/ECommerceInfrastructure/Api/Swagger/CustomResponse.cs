using ECommerceCommon;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInfrastructure.Api.Swagger;

public sealed class Success(Type type) : ProducesResponseTypeAttribute(type, 200);
public sealed class Created() : ProducesResponseTypeAttribute(201);
public sealed class NoContent() : ProducesResponseTypeAttribute(typeof(CustomExceptionResponse), 204);
public sealed class BadRequest() : ProducesResponseTypeAttribute(typeof(CustomExceptionResponse), 400);
public sealed class Unauthorized() : ProducesResponseTypeAttribute(typeof(CustomExceptionResponse), 401);
public sealed class Forbidden() : ProducesResponseTypeAttribute(typeof(CustomExceptionResponse), 403);
public sealed class NotFound() : ProducesResponseTypeAttribute(typeof(CustomExceptionResponse), 404);
public sealed class InternalError() : ProducesResponseTypeAttribute(typeof(CustomExceptionResponse), 500);
