using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceMailService.Configuration;

public static partial class MailSetup
{
    public static void SmtpClient(IServiceCollection services)
    {
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
