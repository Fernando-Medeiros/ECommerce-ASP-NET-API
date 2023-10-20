using Microsoft.Extensions.Configuration;

namespace ECommercePersistence;

public static class PersistenceEnvironment
{
    public static string? DefaultConnection { get; private set; }

    public static string? CacheConnection { get; private set; }

    public static void Configure(IConfiguration env)
    {
        DefaultConnection = env["DB_DEFAULT_CONNECTION"];

        CacheConnection = env["CACHE_CONNECTION"];
    }
}