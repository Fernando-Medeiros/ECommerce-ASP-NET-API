using System.Text;
using ECommerce.Startup.Environment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void AddAuthenticationMiddleware(WebApplicationBuilder b)
    {
        b.Services
            .AddAuthentication(opt =>
            {
                string scheme = JwtBearerDefaults.AuthenticationScheme;

                opt.DefaultAuthenticateScheme = scheme;
                opt.DefaultChallengeScheme = scheme;
            })
            .AddJwtBearer(opt =>
            {
                byte[] key = Encoding.ASCII.GetBytes(AuthCredential.PrivateKey!);

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

    public static void AddAuthorizationMiddleware(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(opt =>
        {
            opt.AddPolicy("Manager", policy => policy.RequireRole("manager"));
            opt.AddPolicy("Employee", policy => policy.RequireRole("employee"));
        });
    }

    public static void UseAuthorizationMiddleware(WebApplication app)
    {
        app.UseAuthorization();
    }

    public static void UseAuthenticationMiddleware(WebApplication app)
    {
        app.UseAuthentication();
    }
}
