namespace ECommerce.Modules.CustomerAddress;

using ECommerce.Exceptions;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _repository;

    public AddressService(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AddressDTO?>> FindAddresses(string customerId)
    {
        return await _repository.FindAddresses(customerId);
    }

    public async Task<AddressDTO> FindOne(string addressId, string customerId)
    {
        return await _repository.FindOne(addressId, customerId)
            ?? throw new NotFoundError("Address Not Found");
    }

    public async Task Register(AddressCreateDTO dto)
    {
        await _repository.Register(dto);
    }

    public async Task Update(AddressUpdateDTO dto)
    {
        AddressDTO address = await FindOne(dto.Id!, dto.CustomerId!);

        dto.UpdateProperties(ref address);

        await _repository.Update(address);
    }

    public async Task Remove(string addressId, string customerId)
    {
        AddressDTO address = await FindOne(addressId, customerId);

        await _repository.Remove(address);
    }
}