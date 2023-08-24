using ECommerce.Events.Mail;
using ECommerce.Modules.Auth;
using ECommerce.Modules.Category;
using ECommerce.Modules.Customer;
using ECommerce.Modules.CustomerCart;
using ECommerce.Modules.CustomerAddress;
using ECommerce.Modules.CustomerPassword;
using ECommerce.Modules.Product;
using ECommerce.Modules.Sales;
using ECommerce.ModulesHelpers.Mail;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Injectable(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddScoped<IAuthService, AuhService>();

        builder.Services.AddScoped<IAddressRepository, AddressRepository>();
        builder.Services.AddScoped<IAddressService, AddressService>();

        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartService, CartService>();

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

        builder.Services.AddScoped<ICustomerPasswordRepository, CustomerPasswordRepository>();
        builder.Services.AddScoped<ICustomerPasswordService, CustomerPasswordService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<ISalesRepository, SalesRepository>();
        builder.Services.AddScoped<ISalesService, SalesService>();

        builder.Services.AddTransient<ITokenService, TokenService>();

        builder.Services.AddTransient<IMailService, MailService>();

        builder.Services.AddTransient<ICustomerMailEvent, CustomerMailEvent>();
        builder.Services.AddTransient<IPasswordMailEvent, PasswordMailEvent>();
    }
}
