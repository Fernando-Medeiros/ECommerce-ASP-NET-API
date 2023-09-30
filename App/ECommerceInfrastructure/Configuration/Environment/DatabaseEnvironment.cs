namespace ECommerceInfrastructure.Configuration.Environment;

public static class DatabaseEnvironment
{
    public static string? DefaultConnectionString { get; private set; }

    public static void LoadEnv(IConfiguration x)
    {
        DefaultConnectionString = x.GetValue<string>("DB_DEFAULT_CONNECTION");
    }
}