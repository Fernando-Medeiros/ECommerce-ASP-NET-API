using Microsoft.Extensions.Configuration;

namespace ECommerceMailService.Configuration;

public static class MailEnvironment
{
    internal static string? User { get; private set; }
    internal static string? Pass { get; private set; }
    internal static string? Host { get; private set; }
    internal static int Port { get; private set; }
    internal static bool Encryption { get; private set; }
    internal static string? FromName { get; private set; }
    internal static string? FromAddress { get; private set; }


    internal static string? AuthenticateEmailURL { get; private set; }
    internal static string? ResetPasswordURL { get; private set; }


    public static void Configure(IConfiguration x)
    {
        User = x.GetValue<string>("MAIL_USER");
        Pass = x.GetValue<string>("MAIL_PASS");
        Host = x.GetValue<string>("MAIL_HOST");
        Port = x.GetValue<int>("MAIL_PORT");
        Encryption = x.GetValue<bool>("MAIL_ENCRYPTION");
        FromName = x.GetValue<string>("MAIL_FROM_NAME");
        FromAddress = x.GetValue<string>("MAIL_FROM_ADDRESS");

        AuthenticateEmailURL = x.GetValue<string>("URL_AUTH_EMAIL");
        ResetPasswordURL = x.GetValue<string>("URL_RESET_PASS");
    }
}
