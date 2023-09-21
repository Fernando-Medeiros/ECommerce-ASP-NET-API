using ECommerceDomain.Validators;

namespace ECommerceApplication.Requests;

public sealed record CreateCustomerRequest
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
            new CustomValidator<string?>(
                data: Name, target: nameof(Name))
                .NotNull()
                .NotEmpty()
                .Length(3, 20);
        }),

        Task.Run(() =>
        {
            new CustomValidator<string?>(
                data: FirstName, target: nameof(FirstName))
                .NotNull()
                .NotEmpty()
                .Length(3, 20);
        }),

    Task.Run(() =>
    {
        new CustomValidator<string?>(
                data: LastName, target: nameof(LastName))
                .NotNull()
                .NotEmpty()
                .Length(3, 20);
    }),

    Task.Run(() =>
    {
        new CustomValidator<string?>(
                data: Email, target: nameof(Email))
                .NotNull()
                .NotEmpty()
                .Length(6, 155)
                .EmailAddress();
    }),

    Task.Run(() =>
    {
        new CustomValidator<string?>(
                data: Password, target: nameof(Password))
                .NotNull()
                .NotEmpty()
                .Length(8, 16)
                .Password();
    }));
}