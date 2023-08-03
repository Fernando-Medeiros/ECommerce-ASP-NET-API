namespace ECommerce.Startup;

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static partial class ServiceProviders
{
    public static void AddAuthenticationMiddleware(WebApplicationBuilder builder)
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
                byte[] key = Encoding.ASCII.GetBytes(
                        builder.Configuration
                        .GetSection("Environment")
                        .GetValue<string>("PrivateKey")!
                );

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
        builder.Services.AddAuthorization();
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
