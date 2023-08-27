using ECommerce.Startup.Environment;

namespace ECommerce.ModulesHelpers.Mail;

public class ActiveAccountVM
{
    public string Token { get; init; }
    public string UserName { get; init; }
    public string RedirectURL { get; init; }

    public ActiveAccountVM(string name, string token)
    {
        UserName = name;
        Token = token;
        RedirectURL = RedirectUrl.AuthEmailURL + token;
    }
}