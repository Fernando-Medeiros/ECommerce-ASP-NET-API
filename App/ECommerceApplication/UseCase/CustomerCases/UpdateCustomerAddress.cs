using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase.CustomerCases;

public sealed class UpdateCustomerAddress(
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


        AddressDTO address = await _repository.Find(new(Id: identity.Id), cancellationToken)

            ?? throw new AddressNotFoundException().Target(nameof(UpdateCustomerAddress));


        AddressDTO request = payload.Mapper();

        address = new Address(address)
            .UpdateCode(request)
            .UpdateCity(request)
            .UpdateState(request)
            .UpdateStreet(request)
            .Mapper();


        _repository.Update(address);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}