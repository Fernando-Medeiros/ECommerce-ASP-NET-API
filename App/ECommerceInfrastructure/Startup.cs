using ECommerceInfrastructure.Configuration.Environment;
using ECommerceInfrastructure.Configuration.Setup;
using ECommerceInfrastructure.Queue.LogQueue;
using ECommerceMail;
using ECommercePersistence;

namespace ECommerceInfrastructure;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        TokenEnvironment.Configure(configuration);
        MailServiceExtension.Environment(configuration);
        PersistenceServiceExtension.Environment(configuration);

        Setup.AuthenticationSchemes(services);

        Setup.AuthorizationPolicies(services);

        Setup.Swagger(services);

        Setup.Controller(services);

        MailServiceExtension.Configure(services);

        PersistenceServiceExtension.Configure(services);

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