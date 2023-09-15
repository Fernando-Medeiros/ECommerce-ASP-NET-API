namespace ECommerceDomain.DTOs;

public class CustomerDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    public string? Password { get; set; }
    public string? Role { get; set; }

    public DateTimeOffset? VerifiedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
}
