using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ECommerceDomain.DTO;
using ECommerceInfrastructure.Auth.Identities.Claims;
using ECommerceInfrastructure.Auth.Tokens.Enums;
using ECommerceInfrastructure.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceInfrastructure.Auth.Tokens;

public sealed class TokenService : ITokenService
{
    private readonly JwtSecurityTokenHandler _jwtHandler;

    public TokenService() => _jwtHandler = new();

    public Token Generate(CustomerDTO customer, ETokenScope scope)
    {
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimPayload(customer, scope),
            Expires = ExpiresAt(scope),
            SigningCredentials = Credentials(),
        };

        SecurityToken securityToken = _jwtHandler.CreateToken(tokenDescriptor);

        string token = _jwtHandler.WriteToken(securityToken);

        return new Token(token, ETokenType.Bearer, scope);
    }

    #region Private

    private static SigningCredentials Credentials()
    {
        byte[] key = Encoding.ASCII.GetBytes(TokenEnvironment.PrivateKey!);

        return new(
            key: new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256Signature);
    }

    private static DateTime ExpiresAt(ETokenScope scope)
    {
        double expires = scope switch
        {
            ETokenScope.Access => TokenEnvironment.AccessTokenExp,
            ETokenScope.Refresh => TokenEnvironment.RefreshTokenExp,
            ETokenScope.RecoverPassword => TokenEnvironment.RecoverPasswordTokenExp,
            ETokenScope.AuthenticateEmail => TokenEnvironment.AuthenticateEmailTokenExp,
            _ => 0
        };
        return DateTime.UtcNow.AddHours(expires);
    }

    #endregion
}