namespace ECommerceCommon.Exceptions;

public sealed class CustomerNotFoundException() : CustomException(
    code: 404,
    error: nameof(CustomerNotFoundException),
    message: "Customer Not Found",
    details: [])
{ }

