namespace ECommerceCommon.Exceptions;

public sealed class AddressNotFoundException() : CustomException(
    code: 404,
    error: nameof(AddressNotFoundException),
    message: "Address Not Found",
    details: [])
{ }

