using AutoMapper;
using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCases.Customer;

public class UpdateCustomerNameAndEmail : IUseCase<CustomerDTO>
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitTransactionWork _transaction;
    private readonly IMapper _mapper;

    public UpdateCustomerNameAndEmail(
        ICustomerRepository repository,
        IUnitTransactionWork transaction,
        IMapper mapper)
    {
        _repository = repository;
        _transaction = transaction;
        _mapper = mapper;
    }

    public async Task Execute(CustomerDTO data)
    {
        var customerCurrentState = await _repository.FindOne(new() { Id = data.Id })
            ?? throw new CustomerNotFoundException();

        if (data.Email != customerCurrentState.Email &&
            await _repository.FindOne(new() { Email = data.Email }) != null)
        {
            throw new UniqueEmailConstraintException();
        }

        var customerEntity = new CustomerEntity()
            .LoadState(customerCurrentState)
            .UpdateName(data)
            .UpdateEmail(data);

        var customerMapped = _mapper.Map<CustomerDTO>(customerEntity);

        _repository.Update(customerMapped);

        await _transaction.Commit();
    }
}
