using ECommerce.Startup.EnvironmentDTOs;

namespace ECommerce.ModulesHelpers.Mail;

public class ActiveAccountVM
{
    public string UserName { get; init; }
    public string RedirectURL { get; init; }

    private static readonly RedirectUrlDTO _environment = new();

    public ActiveAccountVM(string name, string token)
    {
        UserName = name;
        RedirectURL = _environment.AuthEmailURL + token;
    }
}