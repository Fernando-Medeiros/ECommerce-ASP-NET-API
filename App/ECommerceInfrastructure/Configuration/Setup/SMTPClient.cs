using System.Net;
using System.Net.Mail;
using ECommerceInfrastructure.Configuration.Environment;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static void SmtpClient(IServiceCollection services)
    {
        services
            .AddFluentEmail(
                MailEnv.FromAddress,
                MailEnv.FromName
                )
            .AddRazorRenderer()
            .AddSmtpSender(new SmtpClient()
            {
                Host = MailEnv.Host!,
                Port = MailEnv.Port,
                UseDefaultCredentials = false,
                EnableSsl = MailEnv.Encryption,
                Credentials = new NetworkCredential
                {
                    UserName = MailEnv.User,
                    Password = MailEnv.Pass,
                }
            });
    }
}