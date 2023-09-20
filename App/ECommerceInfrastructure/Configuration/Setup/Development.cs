namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplication Development(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        return app;
    }
}