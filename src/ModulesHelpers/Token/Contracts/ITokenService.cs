using ECommerce.Modules.Customer;

namespace ECommerce.ModulesHelpers.Token;

public interface ITokenService
{
    public TokenDTO Generate(CustomerDTO dto, ETokenScope scope);
}
