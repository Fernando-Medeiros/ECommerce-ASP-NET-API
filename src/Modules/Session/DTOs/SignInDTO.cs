using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Session;

public class SignInDTO
{
    [MinLength(11), MaxLength(150), EmailAddress, Required]
    public string? Email { get; set; }

    [MinLength(8), MaxLength(255), Required]
    public string? Password { get; set; }
}
