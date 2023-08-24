using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.CustomerPassword;

public class PasswordUpdateRequest
{
    private string? _password;

    [Required(ErrorMessage = "The Password is Required")]
    [MinLength(8), MaxLength(255)]
    public string? Password
    {
        get => _password;
        set => _password = value?.Trim();
    }
}
