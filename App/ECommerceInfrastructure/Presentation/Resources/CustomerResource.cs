using System.ComponentModel.DataAnnotations;
using ECommerceDomain.DTOs;

namespace ECommerceInfrastructure.Presentation.Resources;

public readonly struct CustomerResource
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    [EmailAddress]
    public string? Email { get; init; }
    public DateOnly CreatedAt { get; init; }

    public CustomerResource(CustomerDTO x)
    {
        Id = x.Id;
        Name = x.Name;
        FirstName = x.FirstName;
        LastName = x.LastName;
        Email = x.Email;
        CreatedAt = DateOnly.FromDateTime(x.CreatedAt!.Value.DateTime);
    }
}
