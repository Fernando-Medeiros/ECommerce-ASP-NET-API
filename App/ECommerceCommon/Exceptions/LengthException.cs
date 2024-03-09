namespace ECommerceCommon.Exceptions;

public sealed class LengthException(string? target, int min, int max) : CustomException(
    code: 400,
    error: nameof(LengthException),
    message: $"The {target} must be between {min} and {max} characters",
    details: [
        $"min: {min}, max: {max}",
        ]
    )
{ }

