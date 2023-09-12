using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Customer;

public readonly struct CustomerResource
{
    public readonly string? Id { get; init; }
    public readonly string? Name { get; init; }
    public readonly string? FirstName { get; init; }
    public readonly string? LastName { get; init; }
    [EmailAddress]
    public readonly string? Email { get; init; }
    public readonly DateOnly CreatedAt { get; init; }

    public CustomerResource(CustomerDTO x)
    {
        Id = x.Id;
        Name = x.Name;
        FirstName = x.FirstName;
        LastName = x.LastName;
        Email = x.Email;
        CreatedAt = DateOnly.FromDateTime(x.CreatedAt!.Value);
    }
}