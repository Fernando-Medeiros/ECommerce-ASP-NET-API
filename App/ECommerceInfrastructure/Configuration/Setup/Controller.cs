using ECommerceInfrastructure.Interceptor;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Controller(WebApplicationBuilder b)
    {
        b.Services.AddControllers(opt =>
            {
                opt.Filters.Add<InternalExceptionInterceptor>();
                opt.Filters.Add<DatabaseExceptionInterceptor>();
                opt.Filters.Add<HttpExceptionInterceptor>();
                opt.Filters.Add<RequestExceptionInterceptor>();
            }
        );

        b.Services.AddEndpointsApiExplorer();
    }
}