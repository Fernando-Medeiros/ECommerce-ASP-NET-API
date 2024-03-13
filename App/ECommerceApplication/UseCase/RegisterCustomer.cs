using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase;

public sealed class RegisterCustomer(
    ICustomerRepository repository,
    IUnitTransaction transaction,
    ICustomerMailEvent mailEvent,
    ICryptService cryptService)
    : IUseCase<CustomerRequest, bool>
{
    readonly ICryptService _cryptService = cryptService;
    readonly ICustomerMailEvent _mailEvent = mailEvent;
    readonly IUnitTransaction _transaction = transaction;
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

        _mailEvent.OnRegisterCustomer(customer, cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}