using ECommerce.Exceptions;

namespace ECommerce.Startup;

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
