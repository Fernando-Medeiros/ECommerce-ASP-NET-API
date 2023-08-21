using System.Net;
using System.Net.Mail;
using ECommerce.Startup.EnvironmentDTOs;

namespace ECommerce.Startup;

public static partial class ServiceProviders
{
    public static void SmtpClient(WebApplicationBuilder builder)
    {
        MailCredentialDTO _environment = new();

        builder.Services
            .AddFluentEmail(
                _environment.FromAddress,
                _environment.FromName
                )
            .AddSmtpSender(new SmtpClient()
            {
                Host = _environment.Host,
                Port = _environment.Port,
                UseDefaultCredentials = false,
                EnableSsl = _environment.Encryption,
                Credentials = new NetworkCredential
                {
                    UserName = _environment.User,
                    Password = _environment.Pass,
                }
            });
    }
}