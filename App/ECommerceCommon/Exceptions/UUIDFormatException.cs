using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class UUIDFormatException : CustomException
{
    public UUIDFormatException()
        : base(
            status: 500,
            error: nameof(UUIDFormatException),
            message: "Invalid UUID format",
            details: new() {
                "min:36 max:36",
                $"example: {Guid.NewGuid()}"})
    { }
}