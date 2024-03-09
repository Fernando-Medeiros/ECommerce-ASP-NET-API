using ECommerceMail.Contract;
using FluentEmail.Core;
using FluentEmail.Core.Models;

namespace ECommerceMail.Service;

public sealed class MailService(IFluentEmail fluentEmail) : IMailService
{
    private readonly IFluentEmail _fluentEmail = fluentEmail;

    public async Task<SendResponse> SendTemplateAsync(
        BaseTemplate template,
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
        string[] split = Directory
            .GetCurrentDirectory()
            .Split(["ECommerce"], StringSplitOptions.None);

        return split[0] + $"/ECommerce/App/ECommerceMail/Template/{temp}.cshtml";
    }
}
