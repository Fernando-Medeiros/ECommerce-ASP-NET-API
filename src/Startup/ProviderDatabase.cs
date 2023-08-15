using ECommerce.Context;
using ECommerce.Startup.EnvironmentDTOs;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Database(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            string _connectionString = DatabaseCredentialDTO
                .GetDatabaseConnectionString();

            options.UseMySql(
                _connectionString,
                serverVersion: ServerVersion.AutoDetect(_connectionString));
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
