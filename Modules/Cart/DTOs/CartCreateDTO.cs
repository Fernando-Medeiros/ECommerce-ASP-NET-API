namespace ECommerce_ASP_NET_API.Modules.Cart;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CartCreateDTO : CartDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [Required(ErrorMessage = "The Customer is Required")]
    public override string? CustomerId { get; set; }

    [Required(ErrorMessage = "The Product is Required")]
    public override int? ProductId { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    public override int? Quantity { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
