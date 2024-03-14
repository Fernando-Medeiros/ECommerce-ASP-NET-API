using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase;

public sealed class FindCustomer(
    ICustomerRepository repository
    ) : IUseCase<IdentityRequest, CustomerDTO>
{
    readonly ICustomerRepository _repository = repository;

    public async Task<CustomerDTO> Execute(
        IdentityRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        return await _repository.Find(new(Id: req.Id), cancellationToken)

            ?? throw new CustomerNotFoundException().Target(nameof(FindCustomer));
    }
}
