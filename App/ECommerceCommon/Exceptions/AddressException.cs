namespace ECommerceCommon.Exceptions;

public sealed class AddressException() : CustomException(
    code: 400,
    error: nameof(AddressException),
    message: "Invalid address",
    details: [])
{ }
