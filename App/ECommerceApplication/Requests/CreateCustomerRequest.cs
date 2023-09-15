using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Requests;

public class CreateCustomerRequest
{
    private string? _name;
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;


    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3), MaxLength(50)]
    public string? Name
    {
        get => _name;
        set => _name = value!.Trim().ToLower();
    }

    [Required(ErrorMessage = "The FirstName is Required")]
    [MinLength(3), MaxLength(50)]
    public string? FirstName
    {
        get => _firstName;
        set => _firstName = value!.Trim().ToLower();
    }

    [Required(ErrorMessage = "The LastName is Required")]
    [MinLength(3), MaxLength(50)]
    public string? LastName
    {
        get => _lastName;
        set => _lastName = value!.Trim().ToLower();
    }

    [Required(ErrorMessage = "The Email is Required")]
    [MinLength(6), MaxLength(150), EmailAddress]
    public string? Email
    {
        get => _email;
        set => _email = value!.Trim();
    }

    [Required(ErrorMessage = "The Password is Required")]
    [MinLength(8), MaxLength(255)]
    public string? Password
    {
        get => _password;
        set => _password = value!.Trim();
    }
}