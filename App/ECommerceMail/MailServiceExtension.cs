using System.Net;
using System.Net.Mail;
using ECommerceMail.Configuration;
using ECommerceMail.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceMail;

public static class MailServiceExtension
{
    public static void Environment(IConfiguration env)
    {
        MailEnvironment.Configure(env);
    }

    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<IMailService, MailService>();

        services
            .AddFluentEmail(
                MailEnvironment.FromAddress,
                MailEnvironment.FromName
                )
            .AddRazorRenderer()
            .AddSmtpSender(new SmtpClient()
            {
                Host = MailEnvironment.Host!,
                Port = MailEnvironment.Port,
                UseDefaultCredentials = false,
                EnableSsl = MailEnvironment.Encryption,
                Credentials = new NetworkCredential
                {
                    UserName = MailEnvironment.User,
                    Password = MailEnvironment.Pass,
                }
            }
        );
    }
}