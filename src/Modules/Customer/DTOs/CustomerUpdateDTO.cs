namespace ECommerce.Modules.Customer;

public struct CustomerUpdateDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    public static CustomerUpdateDTO ExtractProperties(
        CustomerUpdateRequest _, string id)
    {
        return new()
        {
            Id = id,
            Name = _.Name,
            FirstName = _.FirstName,
            LastName = _.LastName,
            Email = _.Email,
        };
    }

    public readonly void UpdateProperties(ref CustomerDTO customer)
    {
        if (Name != null)
            customer.Name = Name;

        if (FirstName != null)
            customer.FirstName = FirstName;

        if (LastName != null)
            customer.LastName = LastName;

        if (Email != null)
            customer.Email = Email;
    }
}
