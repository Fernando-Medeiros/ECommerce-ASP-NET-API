namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Controller(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
    }
}
