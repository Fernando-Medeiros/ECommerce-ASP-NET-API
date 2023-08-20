using ECommerce.Modules.Customer;

namespace ECommerce.Modules.Session;

public interface ISessionService
{
    public Task<CustomerDTO> FindCustomer(SignInDTO dto);

    public TokenDTO GenerateAccessToken(CustomerDTO dto);
}
