namespace ECommerce.Modules.Customer;

public interface ICustomerRepository
{
    public Task<CustomerDTO?> Find(CustomerDTO dto);

    public Task<CustomerDTO> Register(CustomerDTO customer);

    public Task Update(CustomerDTO customer);

    public Task Remove(CustomerDTO customer);
}