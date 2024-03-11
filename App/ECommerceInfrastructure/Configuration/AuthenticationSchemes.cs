using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceInfrastructure.Configuration;

public static partial class Setup
{
    public static void AuthenticationSchemes(IServiceCollection services)
    {
        services
            .AddAuthentication(opt =>
            {
                string scheme = JwtBearerDefaults.AuthenticationScheme;

                opt.DefaultAuthenticateScheme = scheme;
                opt.DefaultChallengeScheme = scheme;
            })
            .AddJwtBearer(opt =>
            {
                byte[] key = Encoding.ASCII.GetBytes(TokenEnvironment.PrivateKey!);

                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            }
        );
    }
}