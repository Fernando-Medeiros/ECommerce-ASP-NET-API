using ECommerce.Exceptions;

namespace ECommerce.Setup;

public static partial class Setup
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
