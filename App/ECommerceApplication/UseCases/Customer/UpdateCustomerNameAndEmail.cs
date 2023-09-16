using AutoMapper;
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

    public async Task Execute(UpdateCustomerRequest request)
    {
        var customerDto = _mapper.Map<CustomerDTO>(request);

        var customerCurrentState = await _repository.FindOne(new() { Id = customerDto.Id })
            ?? throw new CustomerNotFoundException()
                .SetTarget(nameof(UpdateCustomerNameAndEmail));

        if (request.Email != customerCurrentState.Email &&
            await _repository.FindOne(new() { Email = request.Email }) != null)
        {
            throw new UniqueEmailConstraintException()
                .SetTarget(nameof(UpdateCustomerNameAndEmail)); ;
        }

        var customerEntity = new CustomerEntity()
            .LoadState(customerCurrentState)
            .UpdateName(customerDto)
            .UpdateEmail(customerDto);

        var customerMapped = _mapper.Map<CustomerDTO>(customerEntity);

        _repository.Update(customerMapped);

        await _transaction.Commit();
    }
}
