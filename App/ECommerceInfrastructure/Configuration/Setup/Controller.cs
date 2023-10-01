using ECommerceInfrastructure.Filters;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Controller(IServiceCollection services)
    {
        services.AddControllers(opt =>
            {
                opt.Filters.Add<InternalExceptionFilter>();
                opt.Filters.Add<DatabaseUpdateExceptionFilter>();
                opt.Filters.Add<DomainExceptionFilter>();
            }
        );
        services.AddEndpointsApiExplorer();
    }
}