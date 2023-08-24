namespace ECommerce.Modules.CustomerAddress;

public interface ICustomerAddressRepository
{
    public Task<IEnumerable<AddressDTO?>> FindAddresses(string customerId);

    public Task<AddressDTO?> FindOne(string addressId, string customerId);

    public Task Register(AddressCreateDTO dto);

    public Task Update(AddressDTO dto);

    public Task Remove(AddressDTO dto);
}