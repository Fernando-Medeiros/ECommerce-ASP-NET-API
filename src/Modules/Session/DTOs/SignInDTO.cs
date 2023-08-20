namespace ECommerce.Modules.Session;

public readonly struct SignInDTO
{
    public readonly string Email;
    public readonly string Password;

    public SignInDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public static SignInDTO ExtractProperties(SignInRequest req)
    {
        return new(
            email: req.Email!,
            password: req.Password!);
    }
}
