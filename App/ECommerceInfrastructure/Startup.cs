using ECommerceInfrastructure.Configuration.Setup;
using ECommerceInfrastructure.Queue.LogQueue;

namespace ECommerceInfrastructure;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Setup.Environment();

        Setup.AuthenticationSchemes(services);

        Setup.AuthorizationPolicies(services);

        Setup.Swagger(services);

        Setup.Mapping(services);

        Setup.Controller(services);

        Setup.SmtpClient(services);

        Setup.Database(services);

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