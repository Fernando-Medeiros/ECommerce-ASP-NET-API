using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Modules.Auth;

public interface IAuthService
{
    public Task<CustomerDTO> FindCustomer(SignInDTO dto);

    public TokenDTO GenerateAccessToken(CustomerDTO dto);
}
