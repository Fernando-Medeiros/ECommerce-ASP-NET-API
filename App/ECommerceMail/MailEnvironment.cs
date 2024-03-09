using Microsoft.Extensions.Configuration;

namespace ECommerceMail.Configuration;

internal static class MailEnvironment
{
    public static string? User { get; private set; }
    public static string? Pass { get; private set; }
    public static string? Host { get; private set; }
    public static int Port { get; private set; }
    public static bool Encryption { get; private set; }
    public static string? FromName { get; private set; }
    public static string? FromAddress { get; private set; }

    public static string? AuthenticateEmailURL { get; private set; }
    public static string? ResetPasswordURL { get; private set; }

    public static void Configure(IConfiguration x)
    {
        Pass = x.GetValue<string>("MAIL_PASS");
        User = x.GetValue<string>("MAIL_USER");
        Host = x.GetValue<string>("MAIL_HOST");
        Port = x.GetValue<int>("MAIL_PORT");
        Encryption = x.GetValue<bool>("MAIL_ENCRYPTION");
        FromName = x.GetValue<string>("MAIL_FROM_NAME");
        FromAddress = x.GetValue<string>("MAIL_FROM_ADDRESS");

        AuthenticateEmailURL = x.GetValue<string>("URL_AUTH_EMAIL");
        ResetPasswordURL = x.GetValue<string>("URL_RESET_PASS");
    }
}
