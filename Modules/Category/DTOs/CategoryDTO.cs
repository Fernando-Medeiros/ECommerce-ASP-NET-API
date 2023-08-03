namespace ECommerce.Modules.Category;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ECommerce.Models;

public class CategoryDTO
{
    public virtual int? Id { get; set; }

    [MinLength(3), MaxLength(100)]
    public virtual string? Name { get; set; }

    public virtual DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product>? Products { get; set; }
}
