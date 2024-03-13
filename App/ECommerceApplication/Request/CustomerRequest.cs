using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public sealed record CustomerRequest
{
    private string? _name;
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;

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
        new CustomValidation<string?>(Name, nameof(Name))
            .NotNull()
            .NotEmpty()
            .Length(3, 20);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(FirstName, nameof(FirstName))
            .NotNull()
            .NotEmpty()
            .Length(3, 20);
    }),
    Task.Run(() =>
    {
        new CustomValidation<string?>(LastName, nameof(LastName))
            .NotNull()
            .NotEmpty()
            .Length(3, 20);
    }),
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
            .Password();
    }));
}