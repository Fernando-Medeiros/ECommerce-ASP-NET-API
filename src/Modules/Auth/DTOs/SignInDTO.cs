namespace ECommerce.Modules.Auth;

public readonly struct SignInDTO
{
    public readonly string? Id;
    public readonly string Email;
    public readonly string Password;

    public SignInDTO(string email, string password, string? id)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public static SignInDTO ExtractProperties(
        SignInRequest req, string? customerId = null)
    {
        return new(
            id: customerId,
            email: req.Email!,
            password: req.Password!);
    }
}
