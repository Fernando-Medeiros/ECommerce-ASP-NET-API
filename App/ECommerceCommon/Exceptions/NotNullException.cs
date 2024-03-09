namespace ECommerceCommon.Exceptions;

public sealed class NotNullException(string? target) : CustomException(
    code: 400,
    error: nameof(NotNullException),
    message: $"The {target} is Required",
    details: [
        $"The {target} cannot be null",
        ]
    )
{ }

