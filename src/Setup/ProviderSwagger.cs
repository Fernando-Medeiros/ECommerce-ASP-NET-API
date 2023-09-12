using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ECommerce.Setup;

public static partial class Setup
{
    public static void Swagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(opt =>
        {
            SwaggerSettings.AddTokenSecurityDefinition(opt);

            SwaggerSettings.GenSwaggerApiDoc(opt);
        });
    }
}

static class SwaggerSettings
{
    public static void AddTokenSecurityDefinition(SwaggerGenOptions opt)
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            Description = "Insert the Jwt Token",
            Name = "Authorization",
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Reference = new()
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer",
            },
        };

        opt.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {securityScheme,   Array.Empty<string>()}
        });
    }

    public static void GenSwaggerApiDoc(SwaggerGenOptions opt, string? version = "1")
    {
        opt.SwaggerDoc($"v{version}", new OpenApiInfo()
        {
            Title = "E-Commerce",
            Version = $"v{version}",
            Description = "Back-end API project for an e-commerce",

            TermsOfService = new Uri(
                "https://github.com/Fernando-Medeiros/ECommerce-ASP-NET-API/tree/master/Docs"),

            Contact = new()
            {
                Name = "Contact",
                Url = new Uri("https://github.com/Fernando-Medeiros")
            },

            License = new()
            {
                Name = "License - MIT",
                Url = new Uri("https://opensource.org/licenses/MIT")
            },
        });
    }
}
