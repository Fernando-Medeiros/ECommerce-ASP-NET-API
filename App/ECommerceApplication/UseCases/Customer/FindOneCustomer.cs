using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;

namespace ECommerceApplication.UseCases.Customer;

public sealed class FindOneCustomer : IUseCase<CustomerDTO, CustomerDTO>
{
    private readonly ICustomerRepository _repository;

    public FindOneCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDTO> Execute(CustomerDTO data)
    {
        return await _repository.FindOne(data)
            ?? throw new CustomerNotFoundException().Target(nameof(FindOneCustomer));
    }
}
