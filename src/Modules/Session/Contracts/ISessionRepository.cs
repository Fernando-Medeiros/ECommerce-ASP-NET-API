using ECommerce.Modules.Customer;

namespace ECommerce.Modules.Session;

public interface ISessionRepository
{
    public Task<CustomerDTO?> FindCustomer(string email);
}
