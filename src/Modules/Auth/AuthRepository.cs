using ECommerce.Modules.Customer;

namespace ECommerce.Modules.Auth;

public class AuthRepository : IAuthRepository
{
    private readonly ICustomerRepository _customerRepository;

    public AuthRepository(
        ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDTO?> FindCustomer(string email)
    {
        return await _customerRepository.Find(email: email);
    }
}
