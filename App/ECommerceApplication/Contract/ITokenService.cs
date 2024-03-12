using ECommerceDomain.DTO;
using ECommerceDomain.Enums;

namespace ECommerceApplication.Contract;

public interface ITokenService
{
    public TokenDTO Generate(CustomerDTO dto, ETokenScope scope);
}