namespace ECommerceInfrastructure.Configuration.Environment;

public static class DatabaseEnvironment
{
    public static string? DefaultConnection { get; private set; }

    public static void Configure(IConfiguration x)
    {
        DefaultConnection = x.GetValue<string>("DB_DEFAULT_CONNECTION");
    }
}