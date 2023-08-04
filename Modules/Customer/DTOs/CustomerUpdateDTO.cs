namespace ECommerce.Modules.Customer;

using System.ComponentModel.DataAnnotations;

public class CustomerUpdateDTO
{
    [MinLength(3), MaxLength(50)]
    public string? Name { get; set; }

    [MinLength(3), MaxLength(50)]
    public string? FirstName { get; set; }

    [MinLength(3), MaxLength(50)]
    public string? LastName { get; set; }

    [MinLength(11), MaxLength(150), EmailAddress]
    public string? Email { get; set; }
}
