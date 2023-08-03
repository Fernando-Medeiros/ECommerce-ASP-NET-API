namespace ECommerce_ASP_NET_API.Modules.Session;

using ECommerce_ASP_NET_API.Modules.Customer;

public interface ISessionService
{
    public Task<CustomerDTO> FindCustomer(SignInDTO signInDto);
}
