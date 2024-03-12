namespace ECommerceCommon.Exceptions;

public sealed class TokenException() : CustomException(
    code: 403,
    error: nameof(TokenException),
    message: "Access denied, token incompatible",
    details: []
    )
{ }
