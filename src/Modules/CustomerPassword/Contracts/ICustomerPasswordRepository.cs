using ECommerce.Modules.Customer;

namespace ECommerce.Modules.CustomerPassword;

public interface ICustomerPasswordRepository
{
    public Task<CustomerDTO?> FindCustomer(string? id, string? email);

    public Task UpdateCustomer(CustomerDTO dto);
}