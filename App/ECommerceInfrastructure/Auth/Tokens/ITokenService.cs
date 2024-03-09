using ECommerceDomain.DTO;
using ECommerceInfrastructure.Auth.Tokens.Enums;

namespace ECommerceInfrastructure.Auth.Tokens;

public interface ITokenService
{
    public Token Generate(CustomerDTO dto, ETokenScope scope);
}