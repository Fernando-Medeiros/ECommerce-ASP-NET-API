using System.ComponentModel.DataAnnotations;
using ECommerceDomain.DTO;

namespace ECommerceAPI.Resource;

public readonly struct CustomerResource(CustomerDTO x)
{
    public string? Id { get; init; } = x.Id;
    public string? Name { get; init; } = x.Name;
    public string? FirstName { get; init; } = x.FirstName;
    public string? LastName { get; init; } = x.LastName;
    [EmailAddress]
    public string? Email { get; init; } = x.Email;
    public DateOnly CreatedOn { get; init; } = DateOnly.FromDateTime(x.CreatedOn!.Value.DateTime);
}
