using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Auth;

public class SignInRequest
{
    private string? _email;
    private string? _password;

    [MinLength(11), MaxLength(150), EmailAddress, Required]
    public string? Email
    {
        get => _email;
        set => _email = value?.Trim();
    }

    [MinLength(8), MaxLength(255), Required]
    public string? Password
    {
        get => _password;
        set => _password = value?.Trim();
    }
}