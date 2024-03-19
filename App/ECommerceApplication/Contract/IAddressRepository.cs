using ECommerceDomain.DTO;

namespace ECommerceApplication.Contract;

public interface IAddressRepository
{
    public Task<IEnumerable<AddressDTO>> FindMany(
        AddressDTO dto,
        CancellationToken cancellationToken);

    public Task<AddressDTO?> Find(
        AddressDTO dto,
        CancellationToken cancellationToken = default);
    public void Register(AddressDTO dto);
    public void Update(AddressDTO dto);
    public void Remove(AddressDTO dto);
}
