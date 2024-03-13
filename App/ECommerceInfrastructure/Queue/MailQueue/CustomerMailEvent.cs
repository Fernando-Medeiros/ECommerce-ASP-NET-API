using ECommerceApplication.Contract;
using ECommerceDomain.DTO;
using ECommerceDomain.Enums;
using ECommerceMail.Service;
using ECommerceMail.Template;

namespace ECommerceInfrastructure.Queue.MailQueue;

public sealed class CustomerMailEvent(ITokenService service) : ICustomerMailEvent
{
    readonly ITokenService _tokenService = service;

    public void Subscribe(
        ETokenScope scope,
        CustomerDTO customer,
        CancellationToken cancellationToken)
    {
        var payload = _tokenService.Generate(customer, scope);

        object model = scope switch
        {
            ETokenScope.AuthenticateEmail =>
                new AuthenticateEmailVM(payload.Value, customer.Email!),

            ETokenScope.RecoverPassword =>
                new RecoverPasswordVM(payload.Value, customer.Email!),

            _ => new() { }
        };

        var template = new MailTemplate(
            To: customer.Email!,
            Subject: scope.ToString(),
            Template: scope.ToString(),
            Model: model
        );

        MailQueueHandler.InsertTemplate(template);
    }
}
