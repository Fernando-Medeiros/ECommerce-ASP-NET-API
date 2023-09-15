using ECommerceDomain.Abstractions;

namespace ECommerceDomain.Exceptions;

public sealed class UUIDFormatException : DomainException
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