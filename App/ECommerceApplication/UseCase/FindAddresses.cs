using ECommerceApplication.Contract;
using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;

namespace ECommerceApplication.UseCase;

public sealed class FindAddresses(
    IAddressRepository repository
    ) : IUseCase<IdentityRequest, IEnumerable<AddressDTO>>
{
    readonly IAddressRepository _repository = repository;

    public async Task<IEnumerable<AddressDTO>> Execute(
        IdentityRequest req,
        CancellationToken cancellationToken = default)
    {
        await req.ValidateAsync();


        return await _repository.FindMany(new(CustomerId: req.Id), cancellationToken)

            ?? throw new AddressNotFoundException().Target(nameof(FindAddresses));
    }
}