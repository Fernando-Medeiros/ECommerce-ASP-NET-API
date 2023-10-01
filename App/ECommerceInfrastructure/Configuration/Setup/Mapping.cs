using ECommerceInfrastructure.Persistence.Mappers;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Mapping(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DatabaseMappers));
    }
}