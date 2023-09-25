using ECommerceInfrastructure.Interceptor;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Controller(IServiceCollection services)
    {
        services.AddControllers(opt =>
            {
                opt.Filters.Add<InternalExceptionInterceptor>();
                opt.Filters.Add<DatabaseExceptionInterceptor>();
                opt.Filters.Add<HttpExceptionInterceptor>();
            }
        );
        services.AddEndpointsApiExplorer();
    }
}