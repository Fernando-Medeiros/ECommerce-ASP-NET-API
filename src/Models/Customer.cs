namespace ECommerce.Models;

public class Customer
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<Cart>? Carts { get; set; }
}
