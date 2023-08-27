using ECommerce.Startup.Environment;

namespace ECommerce.ModulesHelpers.Mail;

public class RecoverPasswordVM
{
    public string Token { get; init; }
    public string UserName { get; init; }
    public string RedirectURL { get; init; }

    public RecoverPasswordVM(string name, string token)
    {
        UserName = name;
        Token = token;
        RedirectURL = RedirectUrl.ResetPasswordURL + token;
    }
}
