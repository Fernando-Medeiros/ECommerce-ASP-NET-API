using ECommerceApplication.Contract;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase;

public sealed class RemoveCustomer(
    ICustomerRepository repository,
    IUnitTransaction transaction)
    : IUseCase<CustomerDTO, bool>
{
    readonly ICustomerRepository _repository = repository;
    readonly IUnitTransaction _transaction = transaction;

    public async Task<bool> Execute(
        CustomerDTO req,
        CancellationToken cancellationToken = default)
    {
        var customer = await _repository.Find(req, cancellationToken)
            ?? throw new CustomerNotFoundException().Target(nameof(RemoveCustomer));

        _repository.Remove(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
