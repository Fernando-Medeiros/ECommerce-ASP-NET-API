using ECommerceMail.Configuration;

namespace ECommerceMail.Template;

public sealed record RecoverPasswordVM(
    string Token,
    string UserName
    )
{
    public string? RedirectURL => MailEnvironment.ResetPasswordURL + Token;
}