using FluentEmail.Core;

namespace ECommerce.ModulesHelpers.Mail;

public class MailService : IMailService
{
    private readonly IFluentEmail _fluentEmail;

    public MailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task SendMailAsync(string to, string subject, string body)
    {
        await _fluentEmail
            .To(to)
            .Subject(subject)
            .Body(body)
            .SendAsync();
    }
}