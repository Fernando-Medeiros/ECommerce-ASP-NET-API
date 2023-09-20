using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCases.Customer;

public sealed class UpdateCustomerNameAndEmail : IUseCase<UpdateCustomerRequest>
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitTransactionWork _transaction;

    public UpdateCustomerNameAndEmail(
        ICustomerRepository repository,
        IUnitTransactionWork transaction)
    {
        _repository = repository;
        _transaction = transaction;
    }

    public async Task Execute(UpdateCustomerRequest req)
    {
        var currentState = await _repository.FindOne(new() { Id = req.Id })
            ?? throw new CustomerNotFoundException().Target(nameof(UpdateCustomerNameAndEmail));

        if (req.Email != currentState.Email &&
            await _repository.FindOne(new() { Email = req.Email }) is not null)
        {
            throw new UniqueEmailConstraintException().Target(nameof(UpdateCustomerNameAndEmail)); ;
        }

        CustomerDTO request = req.Mapper();

        CustomerDTO customer = new CustomerEntity(currentState)
            .UpdateName(request)
            .UpdateEmail(request)
            .Mapper();

        _repository.Update(customer);

        await _transaction.Commit();
    }
}
