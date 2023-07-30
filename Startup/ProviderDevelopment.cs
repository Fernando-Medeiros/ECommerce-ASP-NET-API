namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Development(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
