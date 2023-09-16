using ECommerceApplication.Contracts;
using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceInfrastructure.Authentication.Encrypt;
using ECommerceInfrastructure.Authentication.Tokens;
using ECommerceInfrastructure.Authentication.Tokens.Contracts;
using ECommerceInfrastructure.Persistence.Repositories;
using FluentValidation;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void Injectable(WebApplicationBuilder b)
    {
        #region UseCases
        b.Services.AddScoped<FindOneCustomer>();
        b.Services.AddScoped<RegisterCustomer>();
        b.Services.AddScoped<UpdateCustomerNameAndEmail>();
        b.Services.AddScoped<RemoveCustomer>();
        #endregion

        #region Persistence
        b.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        b.Services.AddScoped<IUnitTransactionWork, UnitTransactionWork>();
        #endregion

        #region  Authorization
        b.Services.AddScoped<ICryptPassword, CryptPassword>();
        b.Services.AddTransient<ITokenService, TokenService>();
        #endregion

        #region Validators
        b.Services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerRequestValidator>();
        b.Services.AddScoped<IValidator<UpdateCustomerRequest>, UpdateCustomerRequestValidator>();
        #endregion
    }
}