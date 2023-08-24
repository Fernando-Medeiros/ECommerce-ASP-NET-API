using ECommerce.Modules.Customer;

namespace ECommerce.Modules.Auth;

public interface IAuthRepository
{
    public Task<CustomerDTO?> FindCustomer(string email);
}
