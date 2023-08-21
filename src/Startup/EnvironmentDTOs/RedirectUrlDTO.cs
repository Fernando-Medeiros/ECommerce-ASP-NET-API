using dotenv.net.Utilities;

namespace ECommerce.Startup.EnvironmentDTOs;

public readonly struct RedirectUrlDTO
{
    public readonly string AuthEmailURL;
    public readonly string ResetPasswordURL;

    public RedirectUrlDTO()
    {
        AuthEmailURL = EnvReader.GetStringValue("URL_AUTH_EMAIL");

        ResetPasswordURL = EnvReader.GetStringValue("URL_RESET_PASS");
    }
}
