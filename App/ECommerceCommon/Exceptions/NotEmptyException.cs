using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class NotEmptyException : CustomException
{
    public NotEmptyException(string? target)
        : base(
            status: 400,
            error: nameof(NotEmptyException),
            message: $"The {target} is Required",
            details: new() { $"The {target} cannot be empty" })
    { }
}

