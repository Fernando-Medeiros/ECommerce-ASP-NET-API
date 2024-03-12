namespace ECommerceCommon.Exceptions;

public sealed class InvalidPasswordException() : CustomException(
    code: 404,
    error: nameof(InvalidPasswordException),
    message: "Invalid password",
    details: []
    )
{ }

