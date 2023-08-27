namespace ECommerce.Startup.Environment;

public static class MailCredential
{
    public static string? User { get; set; }
    public static string? Pass { get; set; }
    public static string? Host { get; set; }
    public static int Port { get; set; }
    public static bool Encryption { get; set; }
    public static string? FromName { get; set; }
    public static string? FromAddress { get; set; }

    public static void LoadEnv(IConfiguration conf)
    {
        User = conf.GetValue<string>("MAIL_USER");
        Pass = conf.GetValue<string>("MAIL_PASS");
        Host = conf.GetValue<string>("MAIL_HOST");
        Port = conf.GetValue<int>("MAIL_PORT");
        Encryption = conf.GetValue<bool>("MAIL_ENCRYPTION");
        FromName = conf.GetValue<string>("MAIL_FROM_NAME");
        FromAddress = conf.GetValue<string>("MAIL_FROM_ADDRESS");
    }
}
