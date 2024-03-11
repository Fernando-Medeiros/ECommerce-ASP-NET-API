using ECommerceApplication.Contract;
using ECommercePersistence.Cache;
using ECommercePersistence.Context;
using ECommercePersistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePersistence;

public static class PersistenceServiceExtension
{
    private static string? DefaultConnection { get; set; }
    private static string? CacheConnection { get; set; }

    public static void Environment(IConfiguration env)
    {
        DefaultConnection ??= env["DB_DEFAULT_CONNECTION"];

        CacheConnection ??= env["CACHE_CONNECTION"];
    }

    public static void Configure(IServiceCollection services)
    {
        ConfigureCustomerDatabase(services);
        ConfigureLoggerDatabase(services);
        ConfigureCache(services);

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUnitTransaction, UnitTransaction>();
        services.AddAutoMapper(typeof(DatabaseMapping));
    }

    private static void ConfigureCustomerDatabase(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>((provider, opt) =>
        {
            opt.UseNpgsql(
                DefaultConnection,
                b => b.MigrationsAssembly("ECommerceAPI"));

            opt.AddInterceptors(provider.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<ISaveChangesInterceptor, CustomerCacheSaveInterceptor>();
    }

    private static void ConfigureLoggerDatabase(IServiceCollection services)
    {
        services.AddDbContext<LoggerContext>(opt =>
        {
            opt.UseNpgsql(
                DefaultConnection,
                b => b.MigrationsAssembly("ECommerceAPI"));
        });
    }

    private static void ConfigureCache(IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = CacheConnection;
            opt.InstanceName = "ECommerce";
        });

        services.AddScoped<CustomerCacheRepository>();
    }
}