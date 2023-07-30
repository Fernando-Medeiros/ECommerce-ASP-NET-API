using Microsoft.EntityFrameworkCore;
using ECommerce_ASP_NET_API.Context;

namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Database(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            var host = builder.Configuration.GetConnectionString("DefaultConnection");

            options.UseMySql(
                connectionString: host,
                serverVersion: ServerVersion.AutoDetect(host));
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
