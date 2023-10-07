namespace ECommerceInfrastructure.Configuration.Environment;

public static class PersistenceEnvironment
{
    public static string? DefaultConnection { get; private set; }

    public static string? CacheConnection { get; private set; }

    public static void Configure(IConfiguration x)
    {
        DefaultConnection = x.GetValue<string>("DB_DEFAULT_CONNECTION");

        CacheConnection = x.GetValue<string>("CACHE_CONNECTION");
    }
}