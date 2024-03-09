using ECommerceApplication.UseCase;

namespace ECommerceApplication;

public static class ApplicationServiceExtension
{
    public static readonly List<Type> UseCases =
    [
        typeof(FindOneCustomer),
        typeof(RegisterCustomer),
        typeof(RemoveCustomer),
        typeof(UpdateCustomerNameAndEmail),
    ];
}
