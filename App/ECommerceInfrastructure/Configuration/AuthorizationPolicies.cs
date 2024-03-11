using ECommerceDomain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceInfrastructure.Configuration;

public static partial class Setup
{
    public static void AuthorizationPolicies(IServiceCollection services)
    {
        var roles = Enum.GetNames(typeof(ERole)).ToList();

        services.AddAuthorization(opt =>
        {
            roles.ForEach(role =>
            {
                opt.AddPolicy(role, policy => policy.RequireRole(role));
            });
        });
    }
}