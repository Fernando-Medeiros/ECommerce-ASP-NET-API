using FluentEmail.Core.Models;

namespace ECommerceMail.Service;

public interface IMailService
{
    public Task<SendResponse> SendTemplateAsync(
        MailTemplate template,
        CancellationToken cancellationToken);
}
