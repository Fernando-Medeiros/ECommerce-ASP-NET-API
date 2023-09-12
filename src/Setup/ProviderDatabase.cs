using ECommerce.Context;
using ECommerce.Setup.Environment;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Setup;

public static partial class Setup
{
    public static void Database(WebApplicationBuilder b)
    {
        b.Services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(DatabaseEnvironment.ConnectionString);
        });

        b.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
