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
}