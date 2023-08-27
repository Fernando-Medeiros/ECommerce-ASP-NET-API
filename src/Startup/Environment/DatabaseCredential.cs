namespace ECommerce.Startup.Environment;

public static class DatabaseCredential
{
    private static string? ConnectionString { get; set; }

    public static void LoadEnv(IConfiguration conf)
    {
        ConnectionString = conf.GetValue<string>("DB_DEFAULT_CONNECTION");
    }

    public static string? GetDatabaseConnectionString() => ConnectionString;
}