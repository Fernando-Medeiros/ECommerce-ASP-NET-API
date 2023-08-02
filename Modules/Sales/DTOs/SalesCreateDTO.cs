namespace ECommerce_ASP_NET_API.Modules.Sales;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class SalesCreateDTO : SalesDTO
{
    [JsonIgnore]
    public override int? Id { get; set; }

    [Required(ErrorMessage = "The CustomerId is Required")]
    public override string? CustomerId { get; set; }

    [Required(ErrorMessage = "The ProductId is Required")]
    public override int? ProductId { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    public override decimal? Price { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    public override int? Quantity { get; set; }

    [JsonIgnore]
    public override DateTime? CreatedAt { get; set; }
}
