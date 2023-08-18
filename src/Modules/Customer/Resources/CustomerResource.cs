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

    public CustomerResource(CustomerDTO _)
    {
        Id = _.Id;
        Name = _.Name;
        FirstName = _.FirstName;
        LastName = _.LastName;
        Email = _.Email;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }
}