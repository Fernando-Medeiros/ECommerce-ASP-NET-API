namespace ECommerce_ASP_NET_API.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public Category? Category { get; set; }
}
