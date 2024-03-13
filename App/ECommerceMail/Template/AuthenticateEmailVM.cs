using ECommerceMail.Configuration;

namespace ECommerceMail.Template;

public sealed record AuthenticateEmailVM(
    string Token,
    string UserName)
{
    public string? RedirectURL => MailEnvironment.AuthenticateEmailURL + Token;
}