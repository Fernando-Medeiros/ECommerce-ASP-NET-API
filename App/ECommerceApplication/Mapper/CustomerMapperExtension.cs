using ECommerceApplication.Request;
using ECommerceDomain.DTOs;
using ECommerceDomain.Entities;

namespace ECommerceApplication;

public static class CustomerMapperExtension
{
    public static CustomerDTO Mapper(this CreateCustomerRequest req) =>
        new(
            Email: req?.Email,
            Password: req?.Password,
            Name: req?.Name,
            FirstName: req?.FirstName,
            LastName: req?.LastName);

    public static CustomerDTO Mapper(this UpdateCustomerRequest req) =>
        new(
            Id: req?.Id,
            Email: req?.Email,
            Name: req?.Name,
            FirstName: req?.FirstName,
            LastName: req?.LastName);

    public static CustomerDTO Mapper(this CustomerEntity e) =>
        new(
            Id: e?.Id?.Value,
            Email: e?.Email?.Value,
            Name: e?.Name?.Name.Value,
            FirstName: e?.Name?.FirstName.Value,
            LastName: e?.Name?.LastName.Value,
            Password: e?.Password?.Value,
            Role: e?.Role?.Value,
            CreatedOn: e?.CreatedOn?.Value,
            UpdatedOn: e?.UpdatedOn?.Value,
            VerifiedOn: e?.VerifiedOn?.Value);
}
