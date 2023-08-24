using ECommerce.Events.Mail;
using ECommerce.Modules.Auth;
using ECommerce.Modules.Customer;
using ECommerce.Modules.CustomerCart;
using ECommerce.Modules.CustomerAddress;
using ECommerce.Modules.CustomerPassword;
using ECommerce.Modules.Product;
using ECommerce.Modules.ProductCategory;
using ECommerce.Modules.Sales;
using ECommerce.ModulesHelpers.Mail;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Injectable(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

        builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
        builder.Services.AddScoped<ICustomerAddressService, CustomerAddressService>();

        builder.Services.AddScoped<ICustomerCartRepository, CustomerCartRepository>();
        builder.Services.AddScoped<ICustomerCartService, CustomerCartService>();

        builder.Services.AddScoped<ICustomerPasswordRepository, CustomerPasswordRepository>();
        builder.Services.AddScoped<ICustomerPasswordService, CustomerPasswordService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

        builder.Services.AddScoped<ISalesRepository, SalesRepository>();
        builder.Services.AddScoped<ISalesService, SalesService>();

        builder.Services.AddTransient<ITokenService, TokenService>();

        builder.Services.AddTransient<IMailService, MailService>();

        builder.Services.AddTransient<ICustomerMailEvent, CustomerMailEvent>();
        builder.Services.AddTransient<IPasswordMailEvent, PasswordMailEvent>();
    }
}
