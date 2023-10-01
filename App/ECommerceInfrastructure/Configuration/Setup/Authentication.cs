using System.Text;
using ECommerceInfrastructure.Configuration.Environment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void AuthenticationMiddleware(IServiceCollection services)
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
                byte[] key = Encoding.ASCII.GetBytes(TokenEnv.PrivateKey!);

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

    public static void AuthorizationMiddleware(IServiceCollection services)
    {
        services.AddAuthorization(opt =>
        {
            opt.AddPolicy("Customer", policy => policy.RequireRole("customer"));
            opt.AddPolicy("Employee", policy => policy.RequireRole("employee"));
            opt.AddPolicy("Manager", policy => policy.RequireRole("manager"));
        });
    }
}