using ECommerceDomain.DTO;

namespace ECommerceApplication.Contract;

public interface IAddressRepository : IRepository<AddressDTO>
{
    public Task<IEnumerable<AddressDTO>> FindMany(
        AddressDTO dto,
        CancellationToken cancellationToken);
}
