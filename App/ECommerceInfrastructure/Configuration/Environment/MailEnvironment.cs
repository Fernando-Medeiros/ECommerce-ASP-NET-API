namespace ECommerceInfrastructure.Configuration.Environment;

public static class MailEnvironment
{
    public static string? User { get; private set; }
    public static string? Pass { get; private set; }
    public static string? Host { get; private set; }
    public static int Port { get; private set; }
    public static bool Encryption { get; private set; }
    public static string? FromName { get; private set; }
    public static string? FromAddress { get; private set; }

    public static void LoadEnv(IConfiguration x)
    {
        User = x.GetValue<string>("MAIL_USER");
        Pass = x.GetValue<string>("MAIL_PASS");
        Host = x.GetValue<string>("MAIL_HOST");
        Port = x.GetValue<int>("MAIL_PORT");
        Encryption = x.GetValue<bool>("MAIL_ENCRYPTION");
        FromName = x.GetValue<string>("MAIL_FROM_NAME");
        FromAddress = x.GetValue<string>("MAIL_FROM_ADDRESS");
    }
}
