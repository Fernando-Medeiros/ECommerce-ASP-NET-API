using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Mail;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Events.Mail;

public class PasswordMailEvent : IPasswordMailEvent
{
    private readonly IMailService _mailService;
    private readonly ITokenService _tokenService;

    public PasswordMailEvent(
        IMailService mailService,
        ITokenService tokenService)
    {
        _mailService = mailService;
        _tokenService = tokenService;
    }

    public async void OnRecoverPassword(object? sender, CustomerDTO customer)
    {
        string token = _tokenService.Generate(
            customer, ETokenScope.RecoverPassword).Token;

        await _mailService.SendTemplateAsync(
            customer.Email!, new RecoverPasswordVM(customer.Name!, token));
    }
}