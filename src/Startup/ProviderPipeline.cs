namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Pipeline(WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapControllers();
    }
}
