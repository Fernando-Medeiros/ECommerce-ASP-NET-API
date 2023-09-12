namespace ECommerce.Setup.Environment;

public static class RedirectEnvironment
{
    public static string? AuthEmailURL { get; private set; }
    public static string? ResetPasswordURL { get; private set; }

    public static void LoadEnv(IConfiguration x)
    {
        AuthEmailURL = x.GetValue<string>("URL_AUTH_EMAIL");
        ResetPasswordURL = x.GetValue<string>("URL_RESET_PASS");
    }
}
