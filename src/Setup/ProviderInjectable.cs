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

namespace ECommerce.Setup;

public static partial class Setup
{
    public static void Injectable(WebApplicationBuilder b)
    {
        b.Services.AddScoped<IAuthService, AuthService>();

        b.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        b.Services.AddScoped<ICustomerService, CustomerService>();

        b.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
        b.Services.AddScoped<ICustomerAddressService, CustomerAddressService>();

        b.Services.AddScoped<ICustomerCartRepository, CustomerCartRepository>();
        b.Services.AddScoped<ICustomerCartService, CustomerCartService>();

        b.Services.AddScoped<ICustomerPasswordRepository, CustomerPasswordRepository>();
        b.Services.AddScoped<ICustomerPasswordService, CustomerPasswordService>();

        b.Services.AddScoped<IProductRepository, ProductRepository>();
        b.Services.AddScoped<IProductService, ProductService>();

        b.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        b.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

        b.Services.AddScoped<ISalesRepository, SalesRepository>();
        b.Services.AddScoped<ISalesService, SalesService>();

        b.Services.AddTransient<ITokenService, TokenService>();

        b.Services.AddTransient<IMailService, MailService>();

        b.Services.AddTransient<ICustomerMailEvent, CustomerMailEvent>();
        b.Services.AddTransient<IPasswordMailEvent, PasswordMailEvent>();
    }
}
