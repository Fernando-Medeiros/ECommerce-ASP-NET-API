using ECommerceApplication.UseCase;

namespace ECommerceApplication;

public static class ApplicationServiceExtension
{
    public static readonly List<Type> UseCases =
    [
        typeof(FindCustomer),
        typeof(RegisterCustomer),
        typeof(RemoveCustomer),
        typeof(UpdateName),

        typeof(RegisterToken),
        typeof(AuthenticateCustomer),

        typeof(RecoverPassword),
        typeof(UpdatePassword),

        typeof(FindAddress),
        typeof(FindAddresses),
        typeof(RegisterAddress),
        typeof(RemoveAddress),
        typeof(UpdateAddress),
    ];
}
