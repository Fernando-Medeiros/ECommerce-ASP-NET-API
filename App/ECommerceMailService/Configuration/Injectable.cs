using ECommerceMailService.Contracts;
using ECommerceMailService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceMailService.Configuration;

public static partial class MailSetup
{
    public static void Injectable(IServiceCollection services)
    {
        services.AddScoped<IMailService, MailService>();
    }
}
