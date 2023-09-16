using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Authentication.Identities.Claims;
using ECommerceInfrastructure.Authentication.Tokens.Contracts;
using ECommerceInfrastructure.Authentication.Tokens.DTOs;
using ECommerceInfrastructure.Authentication.Tokens.Enums;
using ECommerceInfrastructure.Configuration.Environment;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceInfrastructure.Authentication.Tokens;

public class TokenService : ITokenService
{
    private readonly JwtSecurityTokenHandler _jwtHandler;

    public TokenService() => _jwtHandler = new();

    public TokenDTO Generate(CustomerDTO customer, ETokenScopes scope)
    {
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentityPayload(customer, scope),
            Expires = ExpiresAt(scope),
            SigningCredentials = Credentials(),
        };

        SecurityToken securityToken = _jwtHandler.CreateToken(tokenDescriptor);

        string token = _jwtHandler.WriteToken(securityToken);

        return new TokenDTO(token, ETokenTypes.Bearer, scope);
    }

    #region Private

    private static SigningCredentials Credentials()
    {
        byte[] key = Encoding.ASCII.GetBytes(AuthEnvironment.PrivateKey!);

        return new(
            key: new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256Signature);
    }

    private static DateTime ExpiresAt(ETokenScopes scope)
    {
        double expires = scope switch
        {
            ETokenScopes.Access => AuthEnvironment.AccessTokenExp,
            ETokenScopes.Refresh => AuthEnvironment.RefreshTokenExp,
            ETokenScopes.RecoverPassword => AuthEnvironment.RecoverPasswordTokenExp,
            ETokenScopes.AuthenticateEmail => AuthEnvironment.AuthenticateEmailTokenExp,
            _ => 0
        };
        return DateTime.UtcNow.AddHours(expires);
    }

    #endregion
}