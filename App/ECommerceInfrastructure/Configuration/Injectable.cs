using ECommerceApplication;
using ECommerceApplication.Contract;
using ECommerceInfrastructure.Auth.Crypt;
using ECommerceInfrastructure.Auth.Tokens;
using ECommerceInfrastructure.Queue.LoggerQueue;
using ECommerceInfrastructure.Queue.MailQueue;
using ECommerceInfrastructure.Queue.MailQueue.MailEvents;
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
        services.AddSingleton<ICryptPassword, CryptPassword>();
        services.AddSingleton<ITokenService, TokenService>();
        #endregion

        #region Events
        services.AddScoped<ICustomerMailEvent, CustomerMailEvent>();
        #endregion

        #region  Hosted
        services.AddHostedService<LoggerQueuePersistence>();
        services.AddHostedService<MailQueueDispatch>();
        #endregion
    }
}
