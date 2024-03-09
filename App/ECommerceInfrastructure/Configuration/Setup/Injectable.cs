using ECommerceApplication;
using ECommerceApplication.Contract;
using ECommerceInfrastructure.Authentication.Encrypt;
using ECommerceInfrastructure.Authentication.Tokens;
using ECommerceInfrastructure.Authentication.Tokens.Contracts;
using ECommerceInfrastructure.Queue.LogQueue;
using ECommerceInfrastructure.Queue.MailQueue;
using ECommerceInfrastructure.Queue.MailQueue.MailEvents;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Injectable(IServiceCollection services)
    {
        #region Application
        ServiceExtension.UseCases
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
        services.AddHostedService<LogQueuePersistence>();
        services.AddHostedService<MailQueueDispatch>();
        #endregion
    }
}
