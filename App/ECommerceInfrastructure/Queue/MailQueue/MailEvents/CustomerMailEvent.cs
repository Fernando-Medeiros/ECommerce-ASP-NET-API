using ECommerceApplication.Contract;
using ECommerceDomain.DTO;
using ECommerceDomain.Enums;
using ECommerceMail.Contract;
using ECommerceMail.Service.Data;
using ECommerceMail.Template;

namespace ECommerceInfrastructure.Queue.MailQueue.MailEvents;

public sealed class CustomerMailEvent(ITokenService service) : ICustomerMailEvent
{
    private readonly ITokenService _tokenService = service;

    public void OnRegisterCustomer(CustomerDTO customer, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) return;

        var payload = _tokenService.Generate(customer, ETokenScope.AuthenticateEmail);

        BaseTemplate template = new OnRegisterCustomerTemplate(
            customer.Email!,
            new AuthenticateEmailVM(payload.Value, customer.Name!));

        MailQueueHandler.InsertTemplate(template);
    }

    public void OnRecoverPassword(CustomerDTO customer, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) return;

        var payload = _tokenService.Generate(customer, ETokenScope.RecoverPassword);

        BaseTemplate template = new OnRecoverPasswordTemplate(
            customer.Email!,
            new RecoverPasswordVM(payload.Value, customer.Name!));

        MailQueueHandler.InsertTemplate(template);
    }
}
