using ECommerce.Exceptions;

namespace ECommerce.Modules.Customer;

public class UniqueEmailConstraintException : BadRequestError
{
    public UniqueEmailConstraintException()
        : base("Email is already in use") { }
}
