using System.Net;
using System.Net.Mail;
using ECommerceInfrastructure.Configuration.Environment;

namespace ECommerceInfrastructure.Configuration.Setup;

public static partial class Setup
{
    public static WebApplicationBuilder SmtpClient(this WebApplicationBuilder builder)
    {
        builder.Services
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
            });
        return builder;
    }
}