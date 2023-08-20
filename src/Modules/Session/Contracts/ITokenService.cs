using ECommerce.Modules.Customer;

namespace ECommerce.Modules.Session;

public interface ITokenService
{
    public TokenDTO Generate(CustomerDTO dto);
}
