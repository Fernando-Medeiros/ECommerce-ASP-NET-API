using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase;

public sealed class UpdateName(
    ITransaction transaction,
    ICustomerRepository repository
    ) : IUseCase<(IdentityRequest, NameRequest), bool>
{
    readonly ITransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<bool> Execute(
        (IdentityRequest, NameRequest) tuple,
        CancellationToken cancellationToken = default)
    {
        var (identity, payload) = tuple;

        await identity.ValidateAsync();
        await payload.ValidateAsync();


        CustomerDTO customer = await _repository.Find(new(Id: identity.Id), cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(UpdateName));


        CustomerDTO request = payload.Mapper();

        customer = new Customer(customer)
            .UpdateName(request)
            .Mapper();


        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
