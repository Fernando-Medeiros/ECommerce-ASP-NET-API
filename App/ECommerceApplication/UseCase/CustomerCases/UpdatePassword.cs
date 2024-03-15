using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase.CustomerCases;

public sealed class UpdatePassword(
    ICryptService cryptService,
    ITransaction transaction,
    ICustomerRepository repository
    ) : IUseCase<(IdentityRequest, PasswordRequest), bool>
{
    readonly ICryptService _cryptService = cryptService;
    readonly ITransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<bool> Execute(
        (IdentityRequest, PasswordRequest) tuple,
        CancellationToken cancellationToken = default)
    {
        var (identity, payload) = tuple;

        await identity.ValidateAsync();
        await payload.ValidateAsync();


        CustomerDTO customer = await _repository.Find(new(Id: identity.Id), cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(UpdatePassword));


        customer = new Customer(customer)
            .UpdatePassword(new(Password: _cryptService.Hash(payload.Password)))
            .Mapper();


        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
