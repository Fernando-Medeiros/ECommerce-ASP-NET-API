namespace ECommerce.Startup.Environment;

public static class RedirectUrl
{
    public static string? AuthEmailURL { get; set; }
    public static string? ResetPasswordURL { get; set; }

    public static void LoadEnv(IConfiguration conf)
    {
        AuthEmailURL = conf.GetValue<string>("URL_AUTH_EMAIL");

        ResetPasswordURL = conf.GetValue<string>("URL_RESET_PASS");
    }
}
