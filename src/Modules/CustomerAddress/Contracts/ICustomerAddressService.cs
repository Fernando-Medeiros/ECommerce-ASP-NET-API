namespace ECommerce.Modules.CustomerAddress;

public interface ICustomerAddressService
{
    public Task<IEnumerable<AddressDTO?>> FindAddresses(string customerId);

    public Task<AddressDTO> FindOne(string addressId, string customerId);

    public Task Register(AddressCreateDTO dto);

    public Task Update(AddressUpdateDTO dto);

    public Task Remove(string addressId, string customerId);
}