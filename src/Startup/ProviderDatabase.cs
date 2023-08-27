using ECommerce.Context;
using ECommerce.Startup.Environment;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Database(WebApplicationBuilder b)
    {
        b.Services.AddDbContext<DatabaseContext>(options =>
        {
            string? _connectionString = DatabaseCredential.GetDatabaseConnectionString();

            options.UseNpgsql(_connectionString);
        });

        b.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
