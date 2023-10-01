using ECommerceDomain.Abstractions;

namespace ECommerceInfrastructure.Filters.Exceptions;

public sealed class InternalException : DomainException
{
    public InternalException(string message, List<string> details)
        : base(
            status: 500,
            error: nameof(InternalException),
            message: message,
            details: details)
    { }
}

