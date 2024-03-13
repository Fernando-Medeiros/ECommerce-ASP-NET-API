using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase;

public sealed class RecoverPassword(
    ICustomerRepository repository,
    ICustomerMailEvent mailEvent
    ) : IUseCase<EmailRequest, bool>
{
    readonly ICustomerMailEvent _mailEvent = mailEvent;
    readonly ICustomerRepository _repository = repository;

    public async Task<bool> Execute(
         EmailRequest req,
         CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        CustomerDTO? customer = await _repository.Find(new() { Email = req.Email }, cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(RecoverPassword));


        _mailEvent.OnRecoverPassword(customer, cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
