namespace ECommerce_ASP_NET_API.Modules.Category.DTOs;

using System.Text.Json.Serialization;

public class CategoryUpdateDTO : CategoryDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    public override string? Name { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
