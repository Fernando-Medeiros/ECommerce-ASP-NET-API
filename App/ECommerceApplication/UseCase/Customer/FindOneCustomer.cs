using ECommerceApplication.Contract;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTOs;

namespace ECommerceApplication.UseCase.Customer;

public sealed class FindOneCustomer(ICustomerRepository repository)
    : IUseCase<CustomerDTO, CustomerDTO>
{
    readonly ICustomerRepository _repository = repository;

    public async Task<CustomerDTO> Execute(
        CustomerDTO req,
        CancellationToken cancellationToken = default)
    {
        return await _repository.Find(new(Id: req.Id), cancellationToken)
            ?? throw new CustomerNotFoundException().Target(nameof(FindOneCustomer));
    }
}
