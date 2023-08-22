using ECommerce.Modules.Customer;

namespace ECommerce.Events;

public interface IMailEvents
{
    public void OnRegisterCustomer(
        object? sender, CustomerDTO customer);

    public void OnRecoverPassword(
        object? sender, CustomerDTO customer);
}