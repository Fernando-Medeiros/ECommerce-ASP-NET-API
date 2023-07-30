namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Middleware(WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
