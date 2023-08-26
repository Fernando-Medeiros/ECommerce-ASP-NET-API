using FluentEmail.Core;

namespace ECommerce.ModulesHelpers.Mail;

public class MailService : IMailService
{
    private readonly IFluentEmail _fluentEmail;

    public MailService(IFluentEmail fluentEmail) => _fluentEmail = fluentEmail;

    public async Task SendTemplateAsync(string to, RecoverPasswordVM model)
    {
        await SendAsync(to, "Recover Password", ETemplates.RecoverPassword, model);
    }

    public async Task SendTemplateAsync(string to, ActiveAccountVM model)
    {
        await SendAsync(to, "Active Your Account", ETemplates.ActiveAccount, model);
    }

    #region Private

    private async Task SendAsync<TModel>(
        string to, string subject, ETemplates template, TModel model)
    {
        await _fluentEmail
            .To(to).Subject(subject)
            .UsingTemplateFromFile(ResolvePath(template), model)
            .SendAsync();
    }

    private static string ResolvePath(ETemplates temp)
    {
        string path = $"/ModulesHelpers/Mail/Templates/{Enum.GetName(temp)}.cshtml";

        return Directory.GetCurrentDirectory() + path;
    }

    #endregion
}