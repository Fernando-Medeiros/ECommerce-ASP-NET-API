using System.Text.Json.Serialization;
using ECommerceCommon.Validations;

namespace ECommerceApplication.Request;

public sealed record UpdateCustomerRequest
{
    private string? _id;
    private string? _name;
    private string? _firstName;
    private string? _lastName;
    private string? _email;

    [JsonIgnore]
    public string? Id { get => _id; set => _id = value; }

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

    public async Task ValidateAsync() => await Task.WhenAll(
        Task.Run(() =>
        {
            new CustomValidation<string?>(
                data: Name, target: nameof(Name), required: false)
                .NotEmpty()
                .Length(3, 20);
        }),
        Task.Run(() =>
        {
            new CustomValidation<string?>(
                data: FirstName, target: nameof(FirstName), required: false)
                .NotEmpty()
                .Length(3, 20);
        }),
        Task.Run(() =>
        {
            new CustomValidation<string?>(
                data: LastName, target: nameof(LastName), required: false)
                .NotEmpty()
                .Length(3, 20);
        }),
        Task.Run(() =>
        {
            new CustomValidation<string?>(
                data: Email, target: nameof(Email), required: false)
                .NotEmpty()
                .Length(6, 155)
                .EmailAddress();
        })
    );
}