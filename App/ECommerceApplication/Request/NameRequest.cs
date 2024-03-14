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
        set => _name = value?.Trim().ToLower();
    }
    public string? FirstName
    {
        get => _firstName;
        set => _firstName = value?.Trim().ToLower();
    }
    public string? LastName
    {
        get => _lastName;
        set => _lastName = value?.Trim().ToLower();
    }

    public async Task ValidateAsync() => await Task.WhenAll(
    Task.Run(() =>
    {
        new CustomValidation<string?>(Name, nameof(Name), Required: false)
            .NotEmpty()
            .Length(3, 20);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(FirstName, nameof(FirstName), Required: false)
            .NotEmpty()
            .Length(3, 20);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(LastName, nameof(LastName), Required: false)
            .NotEmpty()
            .Length(3, 20);
    })
    );
}