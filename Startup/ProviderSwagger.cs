namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Swagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
    }
}
