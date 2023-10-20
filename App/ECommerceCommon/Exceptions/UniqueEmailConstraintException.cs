
using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public class UniqueEmailConstraintException : CustomException
{
    public UniqueEmailConstraintException() : base(
        status: 400,
        error: nameof(UniqueEmailConstraintException),
        message: "Email is already in use",
        details: new() { "The email is already in use in the database" })
    { }
}
