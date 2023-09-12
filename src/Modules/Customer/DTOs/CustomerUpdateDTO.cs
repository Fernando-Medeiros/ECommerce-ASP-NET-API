namespace ECommerce.Modules.Customer;

public readonly struct CustomerUpdateDTO
{
    public readonly string? Id;
    public readonly string? Name;
    public readonly string? FirstName;
    public readonly string? LastName;
    public readonly string? Email;

    public CustomerUpdateDTO(
        string? id,
        string? name,
        string? firstName,
        string? lastName,
        string? email)
    {
        Id = id;

        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static CustomerUpdateDTO ExtractProperties(
        CustomerUpdateRequest req, string id)
    {
        return new(
            id: id,

            name: req.Name,
            firstName: req.FirstName,
            lastName: req.LastName,
            email: req.Email);
    }
}
