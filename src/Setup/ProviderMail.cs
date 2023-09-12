using System.Net;
using System.Net.Mail;
using ECommerce.Setup.Environment;

namespace ECommerce.Setup;

public static partial class Setup
{
    public static void SmtpClient(WebApplicationBuilder b)
    {
        b.Services
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
    }
}