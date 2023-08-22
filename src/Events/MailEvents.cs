using ECommerce.Modules.Customer;
using ECommerce.ModulesHelpers.Mail;
using ECommerce.ModulesHelpers.Token;

namespace ECommerce.Events;

public class MailEvents : IMailEvents
{
    private readonly IMailService _mailService;

    private readonly ITokenService _tokenService;

    public MailEvents(
        IMailService mailService,
        ITokenService tokenService)
    {
        _mailService = mailService;
        _tokenService = tokenService;
    }

    public async void OnRegisterCustomer(
        object? sender, CustomerDTO customer)
    {
        string token = _tokenService.Generate(
            customer, ETokenScope.AuthenticateEmail).Token;

        await _mailService.SendTemplateAsync(
            customer.Email!, new ActiveAccountVM(customer.Name!, token));
    }

    public async void OnRecoverPassword(
        object? sender, CustomerDTO customer)
    {
        string token = _tokenService.Generate(
            customer, ETokenScope.RecoverPassword).Token;

        await _mailService.SendTemplateAsync(
            customer.Email!, new RecoverPasswordVM(customer.Name!, token));
    }
}