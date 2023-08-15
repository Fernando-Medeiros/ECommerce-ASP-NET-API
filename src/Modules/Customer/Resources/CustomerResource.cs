namespace ECommerce.Modules.Customer;

using System.ComponentModel.DataAnnotations;

public struct CustomerResource
{
    public string? Identity { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }
    public DateOnly? CreatedAt { get; set; }

    public CustomerResource(CustomerDTO _)
    {
        Identity = _.Id;
        Name = _.Name;
        FirstName = _.FirstName;
        LastName = _.LastName;
        Email = _.Email;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }
}