using ECommerce.Startup.Environment;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Environment(WebApplicationBuilder b)
    {
        var Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile(
                $"appsettings.{b.Environment.EnvironmentName.ToLower()}.json",
                optional: true)
            .AddEnvironmentVariables()
            .Build();

        AuthCredential.LoadEnv(Configuration);
        DatabaseCredential.LoadEnv(Configuration);
        MailCredential.LoadEnv(Configuration);
        RedirectUrl.LoadEnv(Configuration);
    }
}
