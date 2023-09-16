using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Requests;

public class UpdateCustomerRequest
{
    private string? _name;
    private string? _firstName;
    private string? _lastName;
    private string? _email;

    [MinLength(3), MaxLength(50)]
    public string? Name
    {
        get => _name;
        set => _name = value?.Trim().ToLower();
    }

    [MinLength(3), MaxLength(50)]
    public string? FirstName
    {
        get => _firstName;
        set => _firstName = value?.Trim().ToLower();
    }

    [MinLength(3), MaxLength(50)]
    public string? LastName
    {
        get => _lastName;
        set => _lastName = value?.Trim().ToLower();
    }

    [MinLength(6), MaxLength(150), EmailAddress]
    public string? Email
    {
        get => _email;
        set => _email = value?.Trim();
    }
}