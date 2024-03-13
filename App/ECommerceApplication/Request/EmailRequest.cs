using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public record EmailRequest
{
    private string? _email;

    public string? Email
    {
        get => _email;
        set => _email = value?.Trim();
    }

    public async Task ValidateAsync() => await Task.Run(() =>
    {
        new CustomValidation<string?>(Email, nameof(Email))
            .NotNull()
            .NotEmpty()
            .Length(6, 155)
            .EmailAddress();
    });
}