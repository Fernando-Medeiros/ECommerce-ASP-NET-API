using ECommerceDomain.DTO;
using ECommerceInfrastructure.Authentication.Tokens.DTOs;
using ECommerceInfrastructure.Authentication.Tokens.Enums;

namespace ECommerceInfrastructure.Authentication.Tokens.Contracts;

public interface ITokenService
{
    public TokenDTO Generate(CustomerDTO dto, ETokenScope scope);
}