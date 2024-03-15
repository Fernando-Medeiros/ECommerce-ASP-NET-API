using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase.CustomerCases;

public sealed class FindCustomerAddress(
    IAddressRepository repository
    ) : IUseCase<IdentityRequest, AddressDTO>
{
    readonly IAddressRepository _repository = repository;

    public async Task<AddressDTO> Execute(
        IdentityRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        return await _repository.Find(new(Id: req.Id), cancellationToken)

            ?? throw new AddressNotFoundException().Target(nameof(FindCustomerAddress));
    }
}