using ECommerce.Modules.Customer;

namespace ECommerce.Modules.CustomerPassword;

public class CustomerPasswordRepository : ICustomerPasswordRepository
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerPasswordRepository(
        ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDTO?> FindCustomer(string? id, string? email)
    {
        return await _customerRepository.Find(new() { Id = id, Email = email });
    }

    public async Task UpdateCustomer(CustomerDTO dto)
    {
        await _customerRepository.Update(dto);
    }
}
