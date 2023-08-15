namespace ECommerce.Modules.Customer;

using ECommerce.Exceptions;
using ECommerce.Modules.Cart;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CartDTO?>> FindCarts(string id)
    {
        return await _repository.FindCarts(id);
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

        await _repository.Create(dto);
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
