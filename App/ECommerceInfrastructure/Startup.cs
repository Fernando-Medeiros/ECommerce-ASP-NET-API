using ECommerceInfrastructure.Configuration.Environment;
using ECommerceInfrastructure.Configuration.Setup;
using ECommerceInfrastructure.Queue.LogQueue;
using ECommerceMailService.Configuration;
using ECommercePersistence;

namespace ECommerceInfrastructure;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureEnvironment()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        PersistenceEnvironment.Configure(configuration);
        TokenEnvironment.Configure(configuration);
        MailEnvironment.Configure(configuration);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureEnvironment();

        Setup.AuthenticationSchemes(services);

        Setup.AuthorizationPolicies(services);

        Setup.Swagger(services);

        Setup.Controller(services);

        MailSetup.SmtpClient(services);

        MailSetup.Injectable(services);

        PersistenceSetup.Configure(services);

        Setup.Injectable(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseMiddleware<LogQueueMiddleware>();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}