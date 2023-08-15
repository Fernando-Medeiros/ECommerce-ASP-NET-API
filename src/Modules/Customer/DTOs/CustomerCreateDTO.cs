namespace ECommerce.Modules.Customer;

using BCrypt.Net;

public struct CustomerCreateDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime? CreatedAt { get; set; }

    public static CustomerCreateDTO ExtractProperties(CustomerCreateRequest _)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = _.Name,
            FirstName = _.FirstName,
            LastName = _.LastName,
            Email = _.Email,
            Password = BCrypt.HashPassword(_.Password),
            CreatedAt = DateTime.UtcNow
        };
    }
}
