namespace ECommerce.Setup.Environment;

public static class DatabaseEnvironment
{
    public static string? ConnectionString { get; private set; }

    public static void LoadEnv(IConfiguration x)
    {
        ConnectionString = x.GetValue<string>("DB_DEFAULT_CONNECTION");
    }

}