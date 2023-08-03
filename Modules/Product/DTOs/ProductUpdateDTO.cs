namespace ECommerce.Modules.Product;

using System.Text.Json.Serialization;

public class ProductUpdateDTO : ProductDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
