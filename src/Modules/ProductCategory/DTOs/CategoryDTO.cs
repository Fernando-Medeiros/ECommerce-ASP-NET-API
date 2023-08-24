namespace ECommerce.Modules.ProductCategory;

using ECommerce.Models;

public class CategoryDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? CreatedAt { get; set; }

    public ICollection<Product>? Products { get; set; }
}
