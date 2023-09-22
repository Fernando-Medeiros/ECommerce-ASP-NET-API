using ECommerceApplication.UseCases.Customer;

namespace ECommerceApplication.Configuration;

public static class InjectableServiceExtensions
{
    public static readonly List<Type> UseCases = new()
    {
        typeof(FindOneCustomer),
        typeof(RegisterCustomer),
        typeof(RemoveCustomer),
        typeof(UpdateCustomerNameAndEmail),
    };
}
