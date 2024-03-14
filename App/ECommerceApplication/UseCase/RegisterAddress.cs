using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase;

public sealed class RegisterAddress(
    ITransaction transaction,
    IAddressRepository repository
    ) : IUseCase<(IdentityRequest, AddressRequest), bool>
{
    readonly ITransaction _transaction = transaction;
    readonly IAddressRepository _repository = repository;

    public async Task<bool> Execute(
        (IdentityRequest, AddressRequest) tuple,
        CancellationToken cancellationToken = default)
    {
        var (identity, payload) = tuple;

        await identity.ValidateAsync();
        await payload.ValidateAsync(required: false);


        AddressDTO request = payload.Mapper() with { CustomerId = identity.Id };

        AddressDTO address = new Address()
            .Register(request)
            .Mapper();


        _repository.Register(address);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}