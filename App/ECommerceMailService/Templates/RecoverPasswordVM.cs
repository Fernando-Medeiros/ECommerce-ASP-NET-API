using ECommerceMailService.Configuration;

namespace ECommerceMailService.Templates;

public sealed record RecoverPasswordVM(
    string Token,
    string UserName)
{
    public string? RedirectURL = MailEnvironment.ResetPasswordURL;
}