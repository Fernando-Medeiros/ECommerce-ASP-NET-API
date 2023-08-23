using ECommerce.Events.Mail;
using ECommerce.Exceptions;

namespace ECommerce.Modules.Customer;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    private event EventHandler<CustomerDTO> RegisterCustomerEvent;

    public CustomerService(
        ICustomerRepository repository,
        ICustomerMailEvent _mailEvent)
    {
        _repository = repository;

        RegisterCustomerEvent += _mailEvent.OnRegisterCustomer;
    }

    public async Task<CustomerDTO> FindById(string id)
    {
        return await _repository.Find(id: id)
            ?? throw new NotFoundError("Customer Not Found");
    }

    public async Task Register(CustomerCreateDTO dto)
    {
        if (await EmailExists(dto.Email))
            throw new BadRequestError("Email is already in use");

        CustomerDTO customer = await _repository.Register(dto);

        RegisterCustomerEvent.Invoke(this, customer);
    }

    public async Task Update(CustomerUpdateDTO dto)
    {
        CustomerDTO customer = await FindById(dto.Id!);

        if (dto.Email != null && dto.Email != customer.Email)
        {
            if (await EmailExists(dto.Email))
                throw new BadRequestError("Email is already in use");
        }

        dto.UpdateProperties(ref customer);

        await _repository.Update(customer);
    }

    public async Task Remove(string id)
    {
        CustomerDTO customer = await FindById(id);

        await _repository.Remove(customer);
    }

    private async Task<bool> EmailExists(string? email)
    {
        return await _repository.Find(email: email) != null;
    }
}
