using ECommerceApplication.Configuration;
using ECommerceApplication.Contracts;
using ECommerceInfrastructure.Authentication.Encrypt;
using ECommerceInfrastructure.Authentication.Tokens;
using ECommerceInfrastructure.Authentication.Tokens.Contracts;
using ECommerceInfrastructure.Persistence.Repositories;
using ECommerceInfrastructure.Queue.LogQueue;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Injectable(IServiceCollection services)
    {
        #region Application

        InjectableServiceExtensions.UseCases
            .ForEach(x => services.AddScoped(x));

        #endregion

        #region Persistence
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IUnitTransactionWork, UnitTransactionWork>();
        #endregion

        #region  Authorization
        services.AddScoped<ICryptPassword, CryptPassword>();
        services.AddTransient<ITokenService, TokenService>();
        #endregion

        #region  Hosted
        services.AddHostedService<LogQueuePersistence>();
        #endregion
    }
}
