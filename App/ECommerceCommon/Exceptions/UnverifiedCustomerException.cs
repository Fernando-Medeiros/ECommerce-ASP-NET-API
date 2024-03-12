namespace ECommerceCommon.Exceptions;

public sealed class UnverifiedCustomerException() : CustomException(
    code: 404,
    error: nameof(UnverifiedCustomerException),
    message: "Unverified customer",
    details: [
        "Unverified email",
        ]
    )
{ }

