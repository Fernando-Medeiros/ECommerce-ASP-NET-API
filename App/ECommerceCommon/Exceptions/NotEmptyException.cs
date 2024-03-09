namespace ECommerceCommon.Exceptions;

public sealed class NotEmptyException(string? target) : CustomException(
    code: 400,
    error: nameof(NotEmptyException),
    message: $"The {target} is Required",
    details: [
        $"The {target} cannot be empty",
        ]
    )
{ }

