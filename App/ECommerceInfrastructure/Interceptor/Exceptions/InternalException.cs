using ECommerceDomain.Abstractions;

namespace ECommerceInfrastructure.Interceptor.Exceptions;

public sealed class InternalException : DomainException
{
    public InternalException()
        : base(
            status: 500,
            error: nameof(InternalException),
            message: "",
            details: new() { })
    { }

    public InternalException SetMessage(string message)
    {
        Value.Message = message;
        return this;
    }

    public InternalException SetDetails(List<string> errors)
    {
        Value.Details = errors;
        return this;
    }
}

