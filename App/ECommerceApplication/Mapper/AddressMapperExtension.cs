using ECommerceApplication.Request;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication;

public static class AddressMapperExtension
{
    public static AddressDTO Mapper(this AddressRequest x) =>
        new(Code: x.Code,
            City: x.City,
            State: x.State,
            Street: x.Street);

    public static AddressDTO Mapper(this Address x) =>
        new(Id: x.Id,
            Code: x.Code,
            City: x.City,
            State: x.State,
            Street: x.Street,
            CustomerId: x.CustomerID,
            CreatedOn: x.CreatedOn,
            UpdatedOn: x.UpdatedOn);
}
