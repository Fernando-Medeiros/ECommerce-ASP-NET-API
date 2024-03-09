using ECommerceApplication.UseCase.Customer;

namespace ECommerceApplication;

public static class ServiceExtension
{
    public static readonly List<Type> UseCases =
    [
        typeof(FindOneCustomer),
        typeof(RegisterCustomer),
        typeof(RemoveCustomer),
        typeof(UpdateCustomerNameAndEmail),
    ];
}
