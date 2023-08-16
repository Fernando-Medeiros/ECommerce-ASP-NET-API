namespace ECommerce.Modules.Category;

using System.Text.Json.Serialization;
using ECommerce.Models;

public class CategoryDTO
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public ICollection<Product>? Products { get; set; }
}
