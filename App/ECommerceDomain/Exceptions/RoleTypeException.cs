using ECommerceDomain.Abstractions;
using ECommerceDomain.Enums;

namespace ECommerceDomain.Exceptions;

public sealed class RoleTypeException : DomainException
{
    public RoleTypeException()
        : base(
            status: 404,
            error: nameof(RoleTypeException),
            message: "Invalid role type",
            details: new() { $"options: {Enum.GetNames<ERoles>()}" })
    { }
}
