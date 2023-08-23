namespace ECommerce.Modules.Customer;

public interface ICustomerRepository
{
    public Task<CustomerDTO?> Find(string? id = null, string? email = null);

    public Task<CustomerDTO> Register(CustomerCreateDTO dto);

    public Task Update(CustomerDTO dto);

    public Task Remove(CustomerDTO dto);
}