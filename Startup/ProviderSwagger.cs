namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Swagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }
}
