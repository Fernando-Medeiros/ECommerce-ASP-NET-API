using ECommerceApplication.Contracts;
using ECommercePersistence.Cache;
using ECommercePersistence.Contexts;
using ECommercePersistence.Mappings;
using ECommercePersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePersistence;

public static partial class PersistenceSetup
{
    public static void Configure(IServiceCollection services)
    {
        ConfigureDatabaseOne(services);
        ConfigureDatabaseTwo(services);
        ConfigureCache(services);

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUnitTransactionWork, UnitTransactionWork>();

        services.AddAutoMapper(typeof(DatabaseMappings));
    }

    private static void ConfigureDatabaseOne(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>((provider, opt) =>
        {
            opt.UseNpgsql(
                PersistenceEnvironment.DefaultConnection,
                b => b.MigrationsAssembly("ECommerceInfrastructure"));

            opt.AddInterceptors(provider.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<ISaveChangesInterceptor, CustomerCacheSaveInterceptor>();
    }

    private static void ConfigureDatabaseTwo(IServiceCollection services)
    {
        services.AddDbContext<LoggerContext>(opt =>
        {
            opt.UseNpgsql(
                PersistenceEnvironment.DefaultConnection,
                b => b.MigrationsAssembly("ECommerceInfrastructure"));
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