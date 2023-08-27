namespace ECommerce.ModulesHelpers.Mail;

public interface IMailService
{
    public Task SendTemplateAsync(string to, RecoverPasswordVM model);

    public Task SendTemplateAsync(string to, ActiveAccountVM model);
}