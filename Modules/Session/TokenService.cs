namespace ECommerce_ASP_NET_API.Modules.Session;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ECommerce_ASP_NET_API.Modules.Customer;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly EnvironmentDTO _environment;
    private readonly JwtSecurityTokenHandler _jwtHandler;

    public TokenService(IConfiguration configuration)
    {
        _jwtHandler = new();
        _configuration = configuration;
        _environment = _configuration
            .GetSection("Environment").Get<EnvironmentDTO>()!;
    }

    public TokenDTO Generate(CustomerDTO customer)
    {
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = GeneratePayload(customer),
            Expires = DateTime.UtcNow.AddHours(_environment.TokenExpires),
            SigningCredentials = Credentials(),
        };

        SecurityToken token = _jwtHandler.CreateToken(tokenDescriptor);

        return new() { Token = _jwtHandler.WriteToken(token), Type = "Bearer" };
    }

    private SigningCredentials Credentials()
    {
        byte[] key = Encoding.ASCII.GetBytes(_environment.PrivateKey);

        return new(
            key: new SymmetricSecurityKey(key),
            algorithm: SecurityAlgorithms.HmacSha256Signature
            );
    }

    private static ClaimsIdentity GeneratePayload(CustomerDTO customer)
    {
        ClaimsIdentity claims = new();

        claims.AddClaim(new Claim("id", customer.Id!));

        return claims;
    }
}
