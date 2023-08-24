namespace ECommerce.Modules.CustomerPassword;

public readonly struct PasswordRecoverDTO
{
    public readonly string Email;

    public PasswordRecoverDTO(string email)
    {
        Email = email;
    }
}