
using ECommerce.Events.Mail;
using ECommerce.Exceptions;
using ECommerce.Modules.Customer;

namespace ECommerce.Modules.CustomerPassword;

public class CustomerPasswordService : ICustomerPasswordService
{
    private readonly ICustomerPasswordRepository _repository;

    private event EventHandler<CustomerDTO> RecoverPasswordEvent;

    public CustomerPasswordService(
        ICustomerPasswordRepository repository,
        IPasswordMailEvent _mailEvent)
    {
        _repository = repository;

        RecoverPasswordEvent += _mailEvent.OnRecoverPassword;
    }

    public async Task RecoverPassword(PasswordRecoverDTO dto)
    {
        CustomerDTO customer = await FindCustomer(email: dto.Email);

        RecoverPasswordEvent.Invoke(this, customer);
    }

    public async Task UpdatePassword(PasswordUpdateDTO dto)
    {
        CustomerDTO customer = await FindCustomer(id: dto.Id);

        dto.UpdateProperties(ref customer);

        await _repository.UpdateCustomer(customer);
    }

    private async Task<CustomerDTO> FindCustomer(
        string? id = null, string? email = null)
    {
        return await _repository.FindCustomer(id, email)
            ?? throw new NotFoundError("Customer Not Found");
    }
}
