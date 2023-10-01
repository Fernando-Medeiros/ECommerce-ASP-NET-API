namespace ECommerceInfrastructure.Configuration.Environment;

public static class DatabaseEnv
{
    public static string? DefaultConnection { get; private set; }

    public static void AddEnvironmentVariables(IConfiguration x)
    {
        DefaultConnection = x.GetValue<string>("DB_DEFAULT_CONNECTION");
    }
}