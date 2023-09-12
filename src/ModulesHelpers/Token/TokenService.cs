using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Modules.Customer;
using ECommerce.Setup.Environment;

namespace ECommerce.ModulesHelpers.Token;

public class TokenService : ITokenService
{
    private readonly JwtSecurityTokenHandler _jwtHandler;

    public TokenService() => _jwtHandler = new();

    public TokenDTO Generate(CustomerDTO customer, ETokenScope scope)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = GeneratePayload(customer, scope),
            Expires = ExpiresAt(scope),
            SigningCredentials = Credentials(),
        };

        SecurityToken securityToken = _jwtHandler.CreateToken(tokenDescriptor);

        string token = _jwtHandler.WriteToken(securityToken);

        return new(token, type: ETokenType.Bearer, scope);
    }

    private SigningCredentials Credentials()
    {
        byte[] key = Encoding.ASCII.GetBytes(AuthEnvironment.PrivateKey!);

        return new(
            key: new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256Signature);
    }

    private DateTime ExpiresAt(ETokenScope scope)
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

    private static ClaimsIdentity GeneratePayload(
        CustomerDTO customer,
        ETokenScope tokenScope)
    {
        ClaimsIdentity claims = new();

        claims.AddClaim(new Claim("id", customer.Id!));

        claims.AddClaim(new Claim("scope", Enum.GetName(tokenScope)!));

        if (customer.Role != null)
            claims.AddClaim(new Claim(ClaimTypes.Role, customer.Role!));

        return claims;
    }
}
