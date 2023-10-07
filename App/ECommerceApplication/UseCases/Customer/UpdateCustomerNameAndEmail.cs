using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCases.Customer;

public sealed class UpdateCustomerNameAndEmail : IUseCase<UpdateCustomerRequest, bool>
{
    readonly ICustomerRepository _repository;
    readonly IUnitTransactionWork _transaction;

    public UpdateCustomerNameAndEmail(
        ICustomerRepository repository,
        IUnitTransactionWork transaction)
    {
        _repository = repository;
        _transaction = transaction;
    }

    public async Task<bool> Execute(
        UpdateCustomerRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();

        var currentState = await _repository.FindOne(new(Id: req.Id), cancellationToken)
            ?? throw new CustomerNotFoundException().Target(nameof(UpdateCustomerNameAndEmail));

        if (req.Email != currentState.Email &&
            await _repository.FindOne(new(Email: req.Email), cancellationToken) is CustomerDTO)
        {
            throw new UniqueEmailConstraintException().Target(nameof(UpdateCustomerNameAndEmail)); ;
        }

        CustomerDTO request = req.Mapper();

        CustomerDTO customer = new CustomerEntity(currentState)
            .UpdateName(request)
            .UpdateEmail(request)
            .Mapper();

        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
