namespace ECommerceCommon.Exceptions;

public sealed class RoleTypeException() : CustomException(
    code: 400,
    error: nameof(RoleTypeException),
    message: "Invalid role type",
    details: [])
{ }
