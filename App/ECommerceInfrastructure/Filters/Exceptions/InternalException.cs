using ECommerceCommon.Abstractions;

namespace ECommerceInfrastructure.Filters.Exceptions;

public sealed class InternalException : CustomException
{
    public InternalException(string message, List<string> details)
        : base(
            status: 500,
            error: nameof(InternalException),
            message: message,
            details: details)
    { }
}

