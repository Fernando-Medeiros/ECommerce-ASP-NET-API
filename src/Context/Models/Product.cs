namespace ECommerce.Context.Models;

public class Product
{
    public string? Id { get; set; }
    public string? CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public Category? Category { get; set; }
    public ICollection<Cart>? Carts { get; set; }
}