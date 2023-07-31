using ECommerce_ASP_NET_API.Modules.Category;
using ECommerce_ASP_NET_API.Modules.Customer;
using ECommerce_ASP_NET_API.Modules.Customer.Contracts;

namespace ECommerce_ASP_NET_API.Startup;

public static partial class ServiceProviders
{
    public static void Injectable(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
    }
}
