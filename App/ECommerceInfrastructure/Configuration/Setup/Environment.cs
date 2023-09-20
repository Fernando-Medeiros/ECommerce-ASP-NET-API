using ECommerceInfrastructure.Configuration.Environment;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplicationBuilder Environment(this WebApplicationBuilder builder)
    {
        var Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile(
                $"appsettings.{builder.Environment.EnvironmentName.ToLower()}.json",
                optional: true)
            .AddEnvironmentVariables()
            .Build();

        AuthEnvironment.LoadEnv(Configuration);
        DatabaseEnvironment.LoadEnv(Configuration);
        MailEnvironment.LoadEnv(Configuration);
        RedirectEnvironment.LoadEnv(Configuration);

        return builder;
    }
}