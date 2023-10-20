using ECommerceApplication.Contracts;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTOs;

namespace ECommerceApplication.UseCases.Customer;

public sealed class FindOneCustomer : IUseCase<CustomerDTO, CustomerDTO>
{
    readonly ICustomerRepository _repository;

    public FindOneCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerDTO> Execute(
        CustomerDTO req,
        CancellationToken cancellationToken = default)
    {
        return await _repository.FindOne(new(Id: req.Id), cancellationToken)
            ?? throw new CustomerNotFoundException().Target(nameof(FindOneCustomer));
    }
}
