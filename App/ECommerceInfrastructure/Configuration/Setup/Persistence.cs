using ECommerceInfrastructure.Configuration.Environment;
using ECommerceInfrastructure.Persistence.Cache;
using ECommerceInfrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Persistence(IServiceCollection services)
    {
        ConfigureDatabaseOne(services);
        ConfigureDatabaseTwo(services);
        ConfigureCache(services);
    }

    private static void ConfigureDatabaseOne(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>((provider, opt) =>
        {
            opt.UseNpgsql(PersistenceEnvironment.DefaultConnection);
            opt.AddInterceptors(provider.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<ISaveChangesInterceptor, CustomerCacheSaveInterceptor>();
    }

    private static void ConfigureDatabaseTwo(IServiceCollection services)
    {
        services.AddDbContext<LoggerContext>(opt =>
        {
            opt.UseNpgsql(PersistenceEnvironment.DefaultConnection);
        });
    }

    private static void ConfigureCache(IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = PersistenceEnvironment.CacheConnection;
            opt.InstanceName = "ECommerce";
        });

        services.AddScoped<CustomerCacheRepository>();
    }
}