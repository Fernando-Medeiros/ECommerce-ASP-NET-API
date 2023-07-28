namespace ECommerce_ASP_NET_API.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Product>? Products { get; set; }
}
