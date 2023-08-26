namespace ECommerce.Startup.Environment;

public static class DatabaseCredential
{
    public static string? Host { get; set; }
    public static string? Database { get; set; }
    public static string? User { get; set; }
    public static string? Pass { get; set; }
    public static string? Port { get; set; }
    public static string? SSLMode { get; set; }

    public static void LoadEnv(IConfiguration conf)
    {
        Host = conf.GetValue<string>("DB_HOST");
        Database = conf.GetValue<string>("DB_NAME");
        User = conf.GetValue<string>("DB_USER");
        Pass = conf.GetValue<string>("DB_PASS");

        Port = conf.GetValue<string>("DB_PORT");
        SSLMode = conf.GetValue<string>("DB_SSL_MODE");
    }

    public static string GetDatabaseConnectionString()
    {
        return $"""
        Server={Host};
        Database={Database};
        Port={Port};
        User id={User};
        Password={Pass};
        SSL Mode={SSLMode}
        """;
    }
}