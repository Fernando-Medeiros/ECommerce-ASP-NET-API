using ECommerce.Modules.Cart;
using ECommerce.Modules.Category;
using ECommerce.Modules.Customer;
using ECommerce.Modules.Product;
using ECommerce.Modules.Sales;
using ECommerce.Modules.Session;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void Injectable(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICartRepository, CartRepository>();
        builder.Services.AddScoped<ICartService, CartService>();

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<ISalesRepository, SalesRepository>();
        builder.Services.AddScoped<ISalesService, SalesService>();

        builder.Services.AddScoped<ISessionRepository, SessionRepository>();
        builder.Services.AddScoped<ISessionService, SessionService>();

        builder.Services.Configure<EnvironmentDTO>(
            builder.Configuration.GetSection("Environment"));

        builder.Services.AddTransient<TokenService>();
    }
}
