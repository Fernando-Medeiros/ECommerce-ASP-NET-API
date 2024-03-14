using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase;

public sealed class FindAddress(
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

            ?? throw new AddressNotFoundException().Target(nameof(FindAddress));
    }
}