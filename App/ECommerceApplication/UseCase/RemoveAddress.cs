using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase;

public sealed class RemoveAddress(
    ITransaction transaction,
    IAddressRepository repository
    ) : IUseCase<IdentityRequest, bool>
{
    readonly ITransaction _transaction = transaction;
    readonly IAddressRepository _repository = repository;

    public async Task<bool> Execute(
        IdentityRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        AddressDTO address = await _repository.Find(new(Id: req.Id), cancellationToken)

            ?? throw new AddressNotFoundException().Target(nameof(RemoveAddress));


        _repository.Remove(address);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}