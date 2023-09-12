namespace ECommerce.Context.Models;

public class Category
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Product>? Products { get; set; }
}
