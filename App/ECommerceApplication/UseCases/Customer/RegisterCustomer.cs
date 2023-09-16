using AutoMapper;
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

    public async Task Execute(CreateCustomerRequest request)
    {
        if (await _repository.FindOne(new() { Email = request.Email }) != null)
        {
            throw new UniqueEmailConstraintException()
                .SetTarget(nameof(RegisterCustomer));
        }

        request.Password = _crypt.Hash(request.Password);

        var customerDto = _mapper.Map<CustomerDTO>(request);

        var customerEntity = new CustomerEntity().Register(customerDto);

        var customerMapped = _mapper.Map<CustomerDTO>(customerEntity);

        _repository.Register(customerMapped);

        await _transaction.Commit();
    }
}
