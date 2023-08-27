using ECommerce.Exceptions;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Controller(WebApplicationBuilder b)
    {
        b.Services.AddControllers(opt =>
            {
                opt.Filters.Add<HttpExceptionFilter>();
                opt.Filters.Add<DatabaseExceptionFilter>();
            }
        );

        b.Services.AddEndpointsApiExplorer();
    }
}
