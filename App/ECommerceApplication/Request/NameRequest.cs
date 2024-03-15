using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public sealed record NameRequest
{
    private string? _name;
    private string? _firstName;
    private string? _lastName;

    public string? Name
    {
        get => _name;
        set => _name ??= value?.Trim().ToLower();
    }
    public string? FirstName
    {
        get => _firstName;
        set => _firstName ??= value?.Trim().ToLower();
    }
    public string? LastName
    {
        get => _lastName;
        set => _lastName ??= value?.Trim().ToLower();
    }

    public async Task ValidateAsync(bool required = true) => await Task.WhenAll(
    Task.Run(() =>
    {
        new CustomValidation<string?>(Name, nameof(Name), required)
            .NotEmpty()
            .Length(3, 20);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(FirstName, nameof(FirstName), required)
            .NotEmpty()
            .Length(3, 20);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(LastName, nameof(LastName), required)
            .NotEmpty()
            .Length(3, 20);
    })
    );
}