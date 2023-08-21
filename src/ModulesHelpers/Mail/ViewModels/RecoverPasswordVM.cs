using ECommerce.Startup.EnvironmentDTOs;

namespace ECommerce.ModulesHelpers.Mail;

public class RecoverPasswordVM
{
    public string UserName { get; init; }
    public string RedirectURL { get; init; }

    private static readonly RedirectUrlDTO _environment = new();

    public RecoverPasswordVM(string name, string token)
    {
        UserName = name;
        RedirectURL = _environment.ResetPasswordURL + token;
    }
}
