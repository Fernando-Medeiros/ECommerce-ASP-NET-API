namespace ECommerce.Modules.Customer;

public interface ICustomerRepository
{
    public Task<CustomerDTO?> Find(CustomerDTO dto);

    public Task Register(CustomerDTO dto);

    public Task Update(CustomerDTO dto);

    public Task Remove(CustomerDTO dto);
}