using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCase;

public sealed class UpdateCustomerNameAndEmail(
    ICustomerRepository repository,
    IUnitTransaction transaction)
    : IUseCase<UpdateCustomerRequest, bool>
{
    readonly ICustomerRepository _repository = repository;
    readonly IUnitTransaction _transaction = transaction;

    public async Task<bool> Execute(
        UpdateCustomerRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();

        var currentState = await _repository.Find(new(Id: req.Id), cancellationToken)
            ?? throw new CustomerNotFoundException().Target(nameof(UpdateCustomerNameAndEmail));

        if (req.Email != currentState.Email &&
            await _repository.Find(new(Email: req.Email), cancellationToken) is CustomerDTO)
        {
            throw new UniqueEmailConstraintException().Target(nameof(UpdateCustomerNameAndEmail));
        }

        CustomerDTO request = req.Mapper();

        CustomerDTO customer = new Customer(currentState)
            .UpdateName(request)
            .UpdateEmail(request)
            .Mapper();

        _repository.Update(customer);

        await _transaction.Commit(cancellationToken);

        return Task.CompletedTask.IsCompletedSuccessfully;
    }
}
