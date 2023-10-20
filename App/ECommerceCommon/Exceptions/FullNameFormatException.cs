using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class FullNameFormatException : CustomException
{
    public FullNameFormatException()
        : base(
            status: 400,
            error: nameof(FullNameFormatException),
            message: "Invalid full name format",
            details: new() { "Name, first name and last name must be different" })
    { }
}