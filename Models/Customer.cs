namespace ECommerce_ASP_NET_API.Models;

public class Customer
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Cart>? Carts { get; set; }
}
