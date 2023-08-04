using ECommerce.Exceptions;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Controller(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add<HttpExceptionFilter>();
                opt.Filters.Add<DatabaseExceptionFilter>();
            }
        );

        builder.Services.AddEndpointsApiExplorer();
    }
}
