using ECommerceInfrastructure.Configuration.Environment;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Environment()
    {
        var Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        AuthEnvironment.LoadEnv(Configuration);

        DatabaseEnvironment.LoadEnv(Configuration);

        MailEnvironment.LoadEnv(Configuration);

        RedirectEnvironment.LoadEnv(Configuration);
    }
}