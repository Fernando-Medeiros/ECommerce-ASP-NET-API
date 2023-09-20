using System.Text;
using ECommerceInfrastructure.Configuration.Environment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplicationBuilder AuthenticationMiddleware(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(opt =>
            {
                string scheme = JwtBearerDefaults.AuthenticationScheme;

                opt.DefaultAuthenticateScheme = scheme;
                opt.DefaultChallengeScheme = scheme;
            })
            .AddJwtBearer(opt =>
            {
                byte[] key = Encoding.ASCII.GetBytes(AuthEnvironment.PrivateKey!);

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
        return builder;
    }

    public static WebApplicationBuilder AuthorizationMiddleware(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(opt =>
        {
            opt.AddPolicy("Customer", policy => policy.RequireRole("customer"));
            opt.AddPolicy("Employee", policy => policy.RequireRole("employee"));
            opt.AddPolicy("Manager", policy => policy.RequireRole("manager"));
        });
        return builder;
    }
}