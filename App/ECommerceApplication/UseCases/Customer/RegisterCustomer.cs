using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCases.Customer;

public sealed class RegisterCustomer : IUseCase<CreateCustomerRequest>
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitTransactionWork _transaction;
    private readonly ICryptPassword _crypt;

    public RegisterCustomer(
        ICustomerRepository repository,
        IUnitTransactionWork transaction,
        ICryptPassword crypt)
    {
        _repository = repository;
        _transaction = transaction;
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
    }
}