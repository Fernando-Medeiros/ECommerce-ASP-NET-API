using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public sealed record RegisterTokenRequest
{
    private string? _email;
    private string? _password;

    public string? Email
    {
        get => _email;
        set => _email = value?.Trim();
    }
    public string? Password
    {
        get => _password;
        set => _password = value?.Trim();
    }

    public async Task ValidateAsync() => await Task.WhenAll(
    Task.Run(() =>
    {
        new CustomValidation<string?>(Email, nameof(Email))
            .NotNull()
            .NotEmpty()
            .Length(6, 155)
            .EmailAddress();
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(Password, nameof(Password))
            .NotNull()
            .NotEmpty()
            .Length(8, 16)
            .Password();
    }));
}