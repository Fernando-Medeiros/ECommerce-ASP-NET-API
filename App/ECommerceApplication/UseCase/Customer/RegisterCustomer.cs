using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase.Customer;

public sealed class RegisterCustomer(
    ICustomerRepository repository,
    IUnitTransaction transaction,
    ICustomerMailEvent mailEvent,
    ICryptPassword crypt)
    : IUseCase<CreateCustomerRequest, bool>
{
    readonly ICustomerRepository _repository = repository;
    readonly IUnitTransaction _transaction = transaction;
    readonly ICustomerMailEvent _mailEvent = mailEvent;
    readonly ICryptPassword _crypt = crypt;

    public async Task<bool> Execute(
        CreateCustomerRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();

        if (await _repository.Find(new(Email: req.Email), cancellationToken) is CustomerDTO)
        {
            throw new UniqueEmailConstraintException().Target(nameof(RegisterCustomer));
        }

        CustomerDTO request = req.Mapper() with { Password = _crypt.Hash(req.Password) };

        CustomerDTO customer = new CustomerEntity()
            .Register(request)
            .Mapper();

        _repository.Register(customer);

        await _transaction.Commit(cancellationToken);

        _mailEvent.OnRegisterCustomer(customer, cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}