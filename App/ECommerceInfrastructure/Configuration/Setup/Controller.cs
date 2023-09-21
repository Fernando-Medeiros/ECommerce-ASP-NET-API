using ECommerceInfrastructure.Interceptor;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplicationBuilder Controller(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add<InternalExceptionInterceptor>();
                opt.Filters.Add<DatabaseExceptionInterceptor>();
                opt.Filters.Add<HttpExceptionInterceptor>();
            }
        );

        builder.Services.AddEndpointsApiExplorer();
        return builder;
    }
}