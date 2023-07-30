using ECommerce_ASP_NET_API.Exceptions;

namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Controller(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
            { options.Filters.Add<HttpResponseExceptionFilter>(); }
        );

        builder.Services.AddEndpointsApiExplorer();
    }
}
