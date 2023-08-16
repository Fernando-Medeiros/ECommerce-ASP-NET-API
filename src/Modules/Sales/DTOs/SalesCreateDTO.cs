namespace ECommerce.Modules.Sales;

using System.ComponentModel.DataAnnotations;

public class SalesCreateDTO
{

    [Required(ErrorMessage = "The CustomerId is Required")]
    [MinLength(36), MaxLength(36)]
    public string? CustomerId { get; set; }

    [Required(ErrorMessage = "The ProductId is Required")]
    public string? ProductId { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    [Range(1, 999)]
    public int? Quantity { get; set; }
}
