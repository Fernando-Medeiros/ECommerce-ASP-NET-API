using ECommerceMailService.Configuration;

namespace ECommerceMailService.Templates;

public sealed record AuthenticateEmailVM(
    string Token,
    string UserName)
{
    public string? RedirectURL = MailEnvironment.AuthenticateEmailURL;
}