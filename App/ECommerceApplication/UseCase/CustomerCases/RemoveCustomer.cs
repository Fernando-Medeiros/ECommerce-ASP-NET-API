using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase.CustomerCases;

public sealed class RemoveCustomer(
    ITransaction transaction,
    ICustomerRepository repository
    ) : IUseCase<IdentityRequest, bool>
{
    readonly ITransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<bool> Execute(
        IdentityRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        CustomerDTO customer = await _repository.Find(new(Id: req.Id), cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(RemoveCustomer));


        _repository.Remove(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
