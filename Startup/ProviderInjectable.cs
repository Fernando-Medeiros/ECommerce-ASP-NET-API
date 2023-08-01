using ECommerce_ASP_NET_API.Modules.Cart;
using ECommerce_ASP_NET_API.Modules.Category;
using ECommerce_ASP_NET_API.Modules.Customer;
using ECommerce_ASP_NET_API.Modules.Customer.Contracts;
using ECommerce_ASP_NET_API.Modules.Product;

namespace ECommerce_ASP_NET_API.Startup;

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
    }
}
