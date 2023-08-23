using ECommerce.Modules.Customer;

namespace ECommerce.Events.Mail;

public interface ICustomerMailEvent
{
    public void OnRegisterCustomer(object? sender, CustomerDTO dto);
}
