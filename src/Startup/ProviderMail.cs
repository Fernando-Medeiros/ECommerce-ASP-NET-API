using System.Net;
using System.Net.Mail;
using ECommerce.Startup.Environment;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void SmtpClient(WebApplicationBuilder b)
    {
        b.Services
            .AddFluentEmail(
                MailCredential.FromAddress,
                MailCredential.FromName
                )
            .AddRazorRenderer()
            .AddSmtpSender(new SmtpClient()
            {
                Host = MailCredential.Host!,
                Port = MailCredential.Port,
                UseDefaultCredentials = false,
                EnableSsl = MailCredential.Encryption,
                Credentials = new NetworkCredential
                {
                    UserName = MailCredential.User,
                    Password = MailCredential.Pass,
                }
            });
    }
}