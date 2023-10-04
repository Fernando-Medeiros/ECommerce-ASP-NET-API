using ECommerceMailService.Configuration;

namespace ECommerceMailService.Templates;

public sealed record AuthenticateEmailVM(
    string Token,
    string UserName)
{
    internal string? RedirectURL = MailEnvironment.AuthenticateEmailURL;
}