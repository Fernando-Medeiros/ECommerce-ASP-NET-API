using ECommerce.Exceptions;

namespace ECommerce.Modules.Customer;

public class NotFoundCustomerException : NotFoundError
{
    public NotFoundCustomerException()
        : base("Customer Not Found") { }
}
