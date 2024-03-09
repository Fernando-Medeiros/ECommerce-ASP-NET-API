using ECommerceApplication.Contract;
using ECommerceDomain.DTO;
using ECommerceInfrastructure.Authentication.Tokens.Contracts;
using ECommerceInfrastructure.Authentication.Tokens.Enums;
using ECommerceMailService.Contracts;
using ECommerceMailService.Services.Customer;
using ECommerceMailService.Templates;

namespace ECommerceInfrastructure.Queue.MailQueue.MailEvents;

public sealed class CustomerMailEvent : ICustomerMailEvent
{
    private readonly ITokenService _tokenService;

    public CustomerMailEvent(ITokenService service) => _tokenService = service;

    public void OnRegisterCustomer(CustomerDTO customer, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) return;

        var payload = _tokenService.Generate(customer, ETokenScope.AuthenticateEmail);

        ITemplate template = new OnRegisterCustomerTemplate(
            customer.Email!,
            new AuthenticateEmailVM(payload.Token, customer.Name!));

        MailQueueHandler.InsertTemplate(template);
    }

    public void OnRecoverPassword(CustomerDTO customer, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) return;

        var payload = _tokenService.Generate(customer, ETokenScope.RecoverPassword);

        ITemplate template = new OnRecoverPasswordTemplate(
            customer.Email!,
            new RecoverPasswordVM(payload.Token, customer.Name!));

        MailQueueHandler.InsertTemplate(template);
    }
}
