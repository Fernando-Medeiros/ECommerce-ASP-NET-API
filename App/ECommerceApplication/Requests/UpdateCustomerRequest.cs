namespace ECommerceApplication.Requests;

public class UpdateCustomerRequest
{
    private string? _id;
    private string? _name;
    private string? _firstName;
    private string? _lastName;
    private string? _email;

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

    public UpdateCustomerRequest Id(string id) { _id = id; return this; }
}