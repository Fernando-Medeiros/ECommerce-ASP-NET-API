using ECommerceInfrastructure.Configuration.Environment;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Environment()
    {
        var Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        DatabaseEnv.AddEnvironmentVariables(Configuration);
        MailEnv.AddEnvironmentVariables(Configuration);
        TokenEnv.AddEnvironmentVariables(Configuration);
        RedirectEnv.AddEnvironmentVariables(Configuration);
    }
}