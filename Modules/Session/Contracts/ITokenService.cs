namespace ECommerce.Modules.Session;

using ECommerce.Modules.Customer;

public interface ITokenService
{
    public TokenDTO Generate(CustomerDTO customer);
}
