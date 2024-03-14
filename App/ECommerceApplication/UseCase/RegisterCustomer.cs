using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;
using ECommerceDomain.Enums;

namespace ECommerceApplication.UseCase;

public sealed class RegisterCustomer(
    ICustomerRepository repository,
    ITransaction transaction,
    ICustomerMailEvent mailEvent,
    ICryptService cryptService)
    : IUseCase<CustomerRequest, bool>
{
    readonly ICryptService _cryptService = cryptService;
    readonly ICustomerMailEvent _mailEvent = mailEvent;
    readonly ITransaction _transaction = transaction;
    readonly ICustomerRepository _repository = repository;

    public async Task<bool> Execute(
        CustomerRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        if (await _repository.Find(new(Email: req.Email), cancellationToken) is CustomerDTO)
        {
            throw new UniqueEmailConstraintException().Target(nameof(RegisterCustomer));
        }

        CustomerDTO request = req.Mapper() with { Password = _cryptService.Hash(req.Password) };

        CustomerDTO customer = new Customer()
            .Register(request)
            .Mapper();


        _repository.Register(customer);

        await _transaction.Commit(cancellationToken);

        _mailEvent.Subscribe(ETokenScope.AuthenticateEmail, customer, cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}