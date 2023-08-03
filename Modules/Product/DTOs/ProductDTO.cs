namespace ECommerce.Modules.Product;

using ECommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ProductDTO
{
    public virtual int? Id { get; set; }

    [MinLength(3), MaxLength(100)]
    public virtual string? Name { get; set; }

    [MinLength(5), MaxLength(255)]
    public virtual string? Description { get; set; }

    [MinLength(5), MaxLength(255)]
    public virtual string? ImageURL { get; set; }

    public virtual decimal? Price { get; set; }

    [Range(1, 9999)]
    public virtual long? Stock { get; set; }

    public virtual int? CategoryId { get; set; }

    public virtual DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
