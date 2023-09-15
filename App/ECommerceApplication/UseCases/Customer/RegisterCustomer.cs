using AutoMapper;
using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication.UseCases.Customer;

public sealed class RegisterCustomer : IUseCase<CustomerDTO>
{
    private readonly ICustomerRepository _repository;
    private readonly IUnitTransactionWork _transaction;
    private readonly ICryptPassword _crypt;
    private readonly IMapper _mapper;

    public RegisterCustomer(
        ICustomerRepository repository,
        IUnitTransactionWork transaction,
        ICryptPassword crypt,
        IMapper mapper)
    {
        _repository = repository;
        _transaction = transaction;
        _mapper = mapper;
        _crypt = crypt;
    }

    public async Task Execute(CustomerDTO data)
    {
        if (await _repository.FindOne(new() { Email = data.Email }) != null)
            throw new UniqueEmailConstraintException();

        var customerDto = data with { Password = _crypt.Hash(data.Password) };

        var customerEntity = new CustomerEntity().Register(customerDto);

        var customerMapped = _mapper.Map<CustomerDTO>(customerEntity);

        _repository.Register(customerMapped);

        await _transaction.Commit();
    }
}
