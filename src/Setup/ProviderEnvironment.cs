using ECommerce.Setup.Environment;

namespace ECommerce.Setup;

public static partial class Setup
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

        AuthEnvironment.LoadEnv(Configuration);
        DatabaseEnvironment.LoadEnv(Configuration);
        MailEnvironment.LoadEnv(Configuration);
        RedirectEnvironment.LoadEnv(Configuration);
    }
}
