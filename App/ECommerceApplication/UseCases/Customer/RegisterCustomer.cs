using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCases.Customer;

public sealed class RegisterCustomer : IUseCase<CreateCustomerRequest>
{
    readonly ICustomerRepository _repository;
    readonly IUnitTransactionWork _transaction;
    readonly ICustomerMailEvent _mailEvent;
    readonly ICryptPassword _crypt;

    public RegisterCustomer(
        ICustomerRepository repository,
        IUnitTransactionWork transaction,
        ICustomerMailEvent mailEvent,
        ICryptPassword crypt)
    {
        _repository = repository;
        _transaction = transaction;
        _mailEvent = mailEvent;
        _crypt = crypt;
    }

    public async Task Execute(CreateCustomerRequest req)
    {
        await req.ValidateAsync();

        if (await _repository.FindOne(new(Email: req.Email)) is CustomerDTO)
        {
            throw new UniqueEmailConstraintException().Target(nameof(RegisterCustomer));
        }

        CustomerDTO request = req.Mapper() with { Password = _crypt.Hash(req.Password) };

        CustomerDTO customer = new CustomerEntity()
            .Register(request)
            .Mapper();

        _repository.Register(customer);

        await _transaction.Commit();

        _mailEvent.OnRegisterCustomer(customer);
    }
}