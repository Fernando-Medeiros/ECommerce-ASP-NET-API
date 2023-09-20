using ECommerceInfrastructure.Configuration.Environment;
using ECommerceInfrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplicationBuilder Database(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(DatabaseEnvironment.ConnectionString);
        });

        builder.Services.AddAutoMapper(typeof(DatabaseMappers));
        return builder;
    }
}