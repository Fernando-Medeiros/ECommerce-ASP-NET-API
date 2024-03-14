using ECommerceApplication.Request;
using ECommerceDomain.DTO;
using ECommerceDomain.Entities;

namespace ECommerceApplication;

public static class CustomerMapperExtension
{
    public static CustomerDTO Mapper(this CustomerRequest x) =>
        new(Email: x.Email,
            Password: x.Password,
            Name: x.Name,
            FirstName: x.FirstName,
            LastName: x.LastName);

    public static CustomerDTO Mapper(this NameRequest x) =>
        new(Name: x.Name,
            FirstName: x.FirstName,
            LastName: x.LastName);

    public static CustomerDTO Mapper(this Customer x) =>
        new(Id: x.Id,
            Email: x.Email,
            Name: x.Name?.Name,
            FirstName: x.Name?.FirstName,
            LastName: x.Name?.LastName,
            Password: x.Password,
            Role: x.Role,
            CreatedOn: x.CreatedOn,
            UpdatedOn: x.UpdatedOn,
            VerifiedOn: x.VerifiedOn);
}
