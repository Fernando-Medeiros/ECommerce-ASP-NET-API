namespace ECommerce.Modules.Product;

using ECommerce.Models;
using System.Text.Json.Serialization;

public class ProductDTO
{
    public virtual int? Id { get; set; }

    public virtual string? Name { get; set; }

    public virtual string? Description { get; set; }

    public virtual string? ImageURL { get; set; }

    public virtual decimal? Price { get; set; }

    public virtual long? Stock { get; set; }

    public virtual int? CategoryId { get; set; }

    public virtual DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
