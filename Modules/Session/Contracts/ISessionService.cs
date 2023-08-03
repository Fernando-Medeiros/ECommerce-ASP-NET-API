namespace ECommerce.Modules.Session;

using ECommerce.Modules.Customer;

public interface ISessionService
{
    public Task<CustomerDTO> FindCustomer(SignInDTO signInDto);
}
