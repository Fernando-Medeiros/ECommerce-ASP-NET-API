using System.ComponentModel.DataAnnotations;
using ECommerceDomain.DTO;

namespace ECommerceInfrastructure.Api.Resource;

public readonly struct CustomerResource(CustomerDTO x)
{
    public string? Id { get; } = x.Id;
    public string? Name { get; } = x.Name;
    public string? FirstName { get; } = x.FirstName;
    public string? LastName { get; } = x.LastName;
    [EmailAddress]
    public string? Email { get; } = x.Email;
    public DateOnly CreatedOn { get; } = DateOnly.FromDateTime(x.CreatedOn!.Value.DateTime);
}
