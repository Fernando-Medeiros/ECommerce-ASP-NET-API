namespace ECommerceCommon.Exceptions;

public sealed class UniqueEmailConstraintException() : CustomException(
    code: 400,
    error: nameof(UniqueEmailConstraintException),
    message: "Email is already in use",
    details: [
        "The email is already in use in the database",
        ]
    )
{ }
