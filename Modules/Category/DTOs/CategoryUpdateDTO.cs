namespace ECommerce.Modules.Category;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CategoryUpdateDTO : CategoryDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [Required]
    public override string? Name { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
