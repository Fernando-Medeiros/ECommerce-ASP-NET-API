using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;

namespace ECommerceApplication.UseCases.Customer;

public sealed class RemoveCustomer : IUseCase<CustomerDTO>
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitTransactionWork _transaction;

    public RemoveCustomer(
        ICustomerRepository repository,
        IUnitTransactionWork transaction)
    {
        _repository = repository;
        _transaction = transaction;
    }

    public async Task Execute(CustomerDTO data)
    {
        var customerDto = await _repository.FindOne(data)
            ?? throw new CustomerNotFoundException().Target(nameof(RemoveCustomer));

        _repository.Remove(customerDto);

        await _transaction.Commit();
    }
}
