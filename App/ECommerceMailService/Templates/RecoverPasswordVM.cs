using ECommerceMailService.Configuration;

namespace ECommerceMailService.Templates;

public sealed record RecoverPasswordVM(
    string Token,
    string UserName)
{
    internal string? RedirectURL = MailEnvironment.ResetPasswordURL;
}