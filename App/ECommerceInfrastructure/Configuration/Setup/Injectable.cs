using ECommerceApplication.Configuration;
using ECommerceApplication.Contracts;
using ECommerceInfrastructure.Authentication.Encrypt;
using ECommerceInfrastructure.Authentication.Tokens;
using ECommerceInfrastructure.Authentication.Tokens.Contracts;
using ECommerceInfrastructure.Persistence.Repositories;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplicationBuilder Injectable(this WebApplicationBuilder builder)
    {
        #region Application

        InjectableServiceExtensions.UseCases
            .ForEach(x => builder.Services.AddScoped(x));

        InjectableServiceExtensions.RequestValidators
            .ForEach(x => builder.Services.AddScoped(x));

        #endregion

        #region Persistence
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IUnitTransactionWork, UnitTransactionWork>();
        #endregion

        #region  Authorization
        builder.Services.AddScoped<ICryptPassword, CryptPassword>();
        builder.Services.AddTransient<ITokenService, TokenService>();
        #endregion

        return builder;
    }
}
