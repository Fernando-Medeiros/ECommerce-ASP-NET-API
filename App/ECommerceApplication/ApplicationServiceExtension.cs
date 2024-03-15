using ECommerceApplication.UseCase.AuthCases;
using ECommerceApplication.UseCase.CustomerCases;

namespace ECommerceApplication;

public static class ApplicationServiceExtension
{
    public static readonly List<Type> UseCases =
    [
        typeof(GetCustomer),
        typeof(RegisterCustomer),
        typeof(RemoveCustomer),
        typeof(UpdateCustomerName),

        typeof(GetAccessToken),
        typeof(CheckEmail),

        typeof(RecoverPassword),
        typeof(UpdatePassword),

        typeof(FindCustomerAddress),
        typeof(GetCustomerAddresses),
        typeof(RegisterCustomerAddress),
        typeof(RemoveCustomerAddress),
        typeof(UpdateCustomerAddress),
    ];
}
