using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class RoleTypeException : CustomException
{
    public RoleTypeException()
        : base(
            status: 400,
            error: nameof(RoleTypeException),
            message: "Invalid role type",
            details: new() { })
    { }
}
