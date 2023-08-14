namespace ECommerce.Modules.Product;

using ECommerce.Models;
using System.Text.Json.Serialization;

public class ProductDTO
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageURL { get; set; }

    public decimal? Price { get; set; }

    public long? Stock { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }

    [JsonIgnore]
    public ICollection<Cart>? Carts { get; set; }
}