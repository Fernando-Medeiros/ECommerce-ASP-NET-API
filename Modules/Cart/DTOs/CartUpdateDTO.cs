namespace ECommerce_ASP_NET_API.Modules.Cart;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CartUpdateDTO : CartDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [JsonIgnore]
    public override string? CustomerId { get; set; }

    [JsonIgnore]
    public override int? ProductId { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    public override int? Quantity { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
