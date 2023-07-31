namespace ECommerce_ASP_NET_API.Modules.Category;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CategoryCreateDTO : CategoryDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    public override string? Name { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
