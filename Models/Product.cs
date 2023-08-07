namespace ECommerce.Models;

public class Product
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public Category? Category { get; set; }
    public ICollection<Cart>? Carts { get; set; }
}
