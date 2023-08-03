namespace ECommerce_ASP_NET_API.Modules.Session;

using ECommerce_ASP_NET_API.Modules.Customer;

public interface ITokenService
{
    public TokenDTO Generate(CustomerDTO customer);
}
