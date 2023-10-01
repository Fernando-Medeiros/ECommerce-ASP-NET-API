using ECommerceDomain.Enums;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void AuthorizationPolicies(IServiceCollection services)
    {
        var roles = Enum.GetNames(typeof(ERoles)).ToList();

        services.AddAuthorization(opt =>
        {
            roles.ForEach(role =>
            {
                opt.AddPolicy(role, policy => policy.RequireRole(role));
            });
        });
    }
}