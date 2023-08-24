using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.CustomerPassword;

public class PasswordRecoverRequest
{
    private string? _email;

    [Required(ErrorMessage = "The Email is Required")]
    [MinLength(11), MaxLength(150), EmailAddress]
    public string? Email
    {
        get => _email;
        set => _email = value?.Trim();
    }
}
