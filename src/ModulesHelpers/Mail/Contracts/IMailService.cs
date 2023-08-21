namespace ECommerce.ModulesHelpers.Mail;

public interface IMailService
{
    public Task SendMailAsync(string to, string subject, string body);
}