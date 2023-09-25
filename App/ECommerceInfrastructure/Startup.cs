using ECommerceInfrastructure.Configuration.Setup;

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

        Setup.SmtpClient(services);

        Setup.AuthenticationMiddleware(services);

        Setup.AuthorizationMiddleware(services);

        Setup.Controller(services);

        Setup.Swagger(services);

        Setup.Database(services);

        Setup.Injectable(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseHttpsRedirection();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}