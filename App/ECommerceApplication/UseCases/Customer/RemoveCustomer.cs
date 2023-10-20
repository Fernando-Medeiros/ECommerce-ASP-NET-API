using ECommerceApplication.Contracts;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTOs;

namespace ECommerceApplication.UseCases.Customer;

public sealed class RemoveCustomer : IUseCase<CustomerDTO, bool>
{
    readonly ICustomerRepository _repository;
    readonly IUnitTransactionWork _transaction;

    public RemoveCustomer(
        ICustomerRepository repository,
        IUnitTransactionWork transaction)
    {
        _repository = repository;
        _transaction = transaction;
    }

    public async Task<bool> Execute(
        CustomerDTO req,
        CancellationToken cancellationToken = default)
    {
        var customer = await _repository.FindOne(req, cancellationToken)
            ?? throw new CustomerNotFoundException().Target(nameof(RemoveCustomer));

        _repository.Remove(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
