using ECommerceApplication;
using ECommerceApplication.Contract;
using ECommerceInfrastructure.Auth;
using ECommerceInfrastructure.MailQueue;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceInfrastructure.Configuration;

public static partial class Setup
{
    public static void Injectable(IServiceCollection services)
    {
        #region Application
        ApplicationServiceExtension.UseCases
            .ForEach(x => services.AddScoped(x));
        #endregion

        #region  Authorization
        services.AddSingleton<ICryptService, CryptService>();
        services.AddSingleton<ITokenService, TokenService>();
        #endregion

        #region Events
        services.AddScoped<ICustomerMailEvent, CustomerMailEvent>();
        #endregion

        #region  Hosted
        services.AddHostedService<MailQueueDispatch>();
        #endregion
    }
}
