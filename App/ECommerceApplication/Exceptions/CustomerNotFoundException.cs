using ECommerceDomain.Abstractions;

namespace ECommerceApplication.Exceptions;

public sealed class CustomerNotFoundException : DomainException
{
    public CustomerNotFoundException() : base(
        status: 404,
        error: nameof(CustomerNotFoundException),
        message: "Customer Not Found",
        details: new() {
            "The account was not found in the database"})
    { }
}
