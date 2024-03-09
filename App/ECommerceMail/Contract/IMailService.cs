using FluentEmail.Core.Models;

namespace ECommerceMail.Contract;

public interface IMailService
{
    public Task<SendResponse> SendTemplateAsync(
        BaseTemplate template,
        CancellationToken cancellationToken);
}
