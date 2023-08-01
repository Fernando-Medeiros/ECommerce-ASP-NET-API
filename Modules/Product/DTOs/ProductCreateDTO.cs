namespace ECommerce_ASP_NET_API.Modules.Product;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ProductCreateDTO : ProductDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    public override string? Name { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    public override string? Description { get; set; }

    [Required(ErrorMessage = "The ImageURL is Required")]
    public override string? ImageURL { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    public override decimal? Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    public override long? Stock { get; set; }

    [Required(ErrorMessage = "The Category is Required")]
    public override int? CategoryId { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
