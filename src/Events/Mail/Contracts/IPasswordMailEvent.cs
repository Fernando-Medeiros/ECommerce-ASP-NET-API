using ECommerce.Modules.Customer;

namespace ECommerce.Events.Mail;

public interface IPasswordMailEvent
{
    public void OnRecoverPassword(object? sender, CustomerDTO dto);
}
