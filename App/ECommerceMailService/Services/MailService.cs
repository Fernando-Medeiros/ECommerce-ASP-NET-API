using ECommerceMailService.Contracts;
using FluentEmail.Core;
using FluentEmail.Core.Models;

namespace ECommerceMailService.Services;

public sealed class MailService : IMailService
{
    private readonly IFluentEmail _fluentEmail;

    public MailService(IFluentEmail fluentEmail) => _fluentEmail = fluentEmail;

    public async Task<SendResponse> SendTemplateAsync(
        ITemplate template,
        CancellationToken cancellationToken)
    {
        return await _fluentEmail
            .To(template.To)
            .Subject(template.Subject)
            .UsingTemplateFromFile(ResolvePath(template.Template), template.Model)
            .SendAsync(cancellationToken);
    }

    private static string ResolvePath(string temp)
    {
        string path = $"/App/ECommerceMailService/Templates/{temp}.cshtml";

        return Directory.GetCurrentDirectory() + path;
    }
}
