using ECommerceCommon.Abstractions;

namespace ECommerceCommon.Exceptions;

public sealed class NotNullException : CustomException
{
    public NotNullException(string? target)
        : base(
            status: 400,
            error: nameof(NotNullException),
            message: $"The {target} is Required",
            details: new() { $"The {target} cannot be null" })
    { }
}

