namespace ECommerce.Modules.Customer;

public readonly struct CustomerCreateDTO
{
    public readonly string Name;
    public readonly string FirstName;
    public readonly string LastName;
    public readonly string Email;
    public readonly string Password;

    public CustomerCreateDTO(
        string name,
        string firstName,
        string lastName,
        string email,
        string password)
    {
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static CustomerCreateDTO ExtractProperties(
        CustomerCreateRequest req)
    {
        return new(
            name: req.Name!,
            firstName: req.FirstName!,
            lastName: req.LastName!,
            email: req.Email!,
            password: req.Password!);
    }
}
