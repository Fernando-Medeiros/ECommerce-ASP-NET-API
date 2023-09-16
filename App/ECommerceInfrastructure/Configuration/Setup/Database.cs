using ECommerceApplication.Mappers;
using ECommerceInfrastructure.Configuration.Environment;
using ECommerceInfrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Database(WebApplicationBuilder b)
    {
        b.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(DatabaseEnvironment.ConnectionString);
        });

        b.Services.AddAutoMapper(typeof(DatabaseMappers));
        b.Services.AddAutoMapper(typeof(CustomerMapper));
    }
}