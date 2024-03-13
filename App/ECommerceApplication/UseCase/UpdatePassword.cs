using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase;

public sealed class UpdatePassword(
    ICryptService cryptService,
    IUnitTransaction transaction,
    ICustomerRepository repository
    ) : IUseCase<(string, PasswordRequest), bool>
{
    readonly ICryptService _cryptService = cryptService;
    readonly IUnitTransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<bool> Execute(
        (string, PasswordRequest) data,
        CancellationToken cancellationToken = default)
    {
        var (customerID, req) = data;

        await req.ValidateAsync();


        CustomerDTO? customer = await _repository.Find(new() { Id = customerID }, cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(RecoverPassword));


        customer = new Customer(customer)
            .UpdatePassword(new() { Password = _cryptService.Hash(req.Password) })
            .Mapper();


        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
