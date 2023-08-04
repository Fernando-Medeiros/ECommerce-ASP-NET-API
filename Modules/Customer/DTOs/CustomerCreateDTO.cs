using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Customer;

public class CustomerCreateDTO
{
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3), MaxLength(50)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The FirstName is Required")]
    [MinLength(3), MaxLength(50)]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "The LastName is Required")]
    [MinLength(3), MaxLength(50)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "The Email is Required")]
    [MinLength(11), MaxLength(150), EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "The Password is Required")]
    [MinLength(8), MaxLength(255)]
    public string? Password { get; set; }
}
