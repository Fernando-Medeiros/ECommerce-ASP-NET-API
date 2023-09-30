using ECommerceInfrastructure.Configuration.Environment;
using ECommerceInfrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Database(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(DatabaseEnvironment.DefaultConnectionString);
        });

        services.AddDbContext<LoggerContext>(options =>
        {
            options.UseNpgsql(DatabaseEnvironment.DefaultConnectionString);
        });
    }
}