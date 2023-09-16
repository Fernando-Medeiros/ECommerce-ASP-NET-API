using ECommerceDomain.Abstractions;

namespace ECommerceInfrastructure.Interceptor.Exceptions;

public sealed class RequestValidationException : DomainException
{
    public RequestValidationException()
        : base(
            status: 404,
            error: nameof(RequestValidationException),
            message: "",
            details: new() { })
    { }

    public RequestValidationException SetMessage(string message)
    {
        Value.Message = message;
        return this;
    }

    public RequestValidationException SetDetails(List<string> errors)
    {
        Value.Details = errors;
        return this;
    }
}

