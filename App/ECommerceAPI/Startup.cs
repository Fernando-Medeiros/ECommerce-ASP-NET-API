using ECommerceInfrastructure.Configuration;
using ECommerceInfrastructure.Exceptions;
using ECommerceInfrastructure.Queue.LoggerQueue;
using ECommerceMail;
using ECommercePersistence;

namespace ECommerceAPI;

public sealed class Startup
{
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

        services.AddEndpointsApiExplorer();

        services.AddRouting();

        Setup.Swagger(services);

        MailServiceExtension.Configure(services);

        PersistenceServiceExtension.Configure(services);

        Setup.Injectable(services);
    }

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<LoggerMiddleware>();
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseEndpoints(Endpoint.Configure);
    }
}