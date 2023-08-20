using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Modules.Customer;
using ECommerce.Startup.EnvironmentDTOs;

namespace ECommerce.Modules.Session;

public class TokenService : ITokenService
{
    private readonly AuthCredentialDTO _environment;

    private readonly JwtSecurityTokenHandler _jwtHandler;

    public TokenService()
    {
        _jwtHandler = new();
        _environment = new();
    }

    public TokenDTO Generate(CustomerDTO customer)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = GeneratePayload(customer),
            Expires = DateTime.UtcNow.AddHours(_environment.TokenExpires),
            SigningCredentials = Credentials(_environment.PrivateKey),
        };

        SecurityToken token = _jwtHandler.CreateToken(tokenDescriptor);

        return new(token: _jwtHandler.WriteToken(token), type: "Bearer");
    }

    private static SigningCredentials Credentials(string privateKey)
    {
        byte[] key = Encoding.ASCII.GetBytes(privateKey);

        return new(
            key: new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256Signature);
    }

    private static ClaimsIdentity GeneratePayload(CustomerDTO customer)
    {
        ClaimsIdentity claims = new();

        claims.AddClaim(new Claim("id", customer.Id!));

        if (customer.Role != null)
            claims.AddClaim(new Claim(ClaimTypes.Role, customer.Role!));

        return claims;
    }
}
