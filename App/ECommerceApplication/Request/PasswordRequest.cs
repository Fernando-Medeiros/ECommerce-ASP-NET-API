using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public record PasswordRequest
{
    private string? _password;

    public string? Password
    {
        get => _password;
        set => _password = value?.Trim();
    }

    public async Task ValidateAsync() => await Task.Run(() =>
    {
        new CustomValidation<string?>(Password, nameof(Password))
            .NotNull()
            .NotEmpty()
            .Password();
    });
}