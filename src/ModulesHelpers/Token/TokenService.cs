using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Modules.Customer;
using ECommerce.Setup.Environment;
using ECommerce.Identities;

namespace ECommerce.ModulesHelpers.Token;

public class TokenService : ITokenService
{
    private readonly JwtSecurityTokenHandler _jwtHandler;

    public TokenService() => _jwtHandler = new();

    public TokenDTO Generate(CustomerDTO customer, ETokenScope scope)
    {
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentityPayload(customer, scope),
            Expires = ExpiresAt(scope),
            SigningCredentials = Credentials(),
        };

        SecurityToken securityToken = _jwtHandler.CreateToken(tokenDescriptor);

        string token = _jwtHandler.WriteToken(securityToken);

        return new TokenDTO(token, ETokenType.Bearer, scope);
    }

    #region Private

    private static SigningCredentials Credentials()
    {
        byte[] key = Encoding.ASCII.GetBytes(AuthEnvironment.PrivateKey!);

        return new(
            key: new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256Signature);
    }

    private static DateTime ExpiresAt(ETokenScope scope)
    {
        double expires = scope switch
        {
            ETokenScope.Access => AuthEnvironment.AccessTokenExp,
            ETokenScope.Refresh => AuthEnvironment.RefreshTokenExp,
            ETokenScope.RecoverPassword => AuthEnvironment.RecoverPasswordTokenExp,
            ETokenScope.AuthenticateEmail => AuthEnvironment.AuthenticateEmailTokenExp,
            _ => 0
        };
        return DateTime.UtcNow.AddHours(expires);
    }

    #endregion
}
