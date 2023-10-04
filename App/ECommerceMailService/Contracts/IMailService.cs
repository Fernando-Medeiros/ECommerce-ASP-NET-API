using FluentEmail.Core.Models;

namespace ECommerceMailService.Contracts;

public interface IMailService
{
    public Task<SendResponse> SendTemplateAsync(
        ITemplate template,
        CancellationToken cancellationToken);
}
