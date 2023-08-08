namespace ECommerce.Modules.Cart;

using System.ComponentModel.DataAnnotations;

public class CartCreateDTO
{
    [Required(ErrorMessage = "The Product is Required")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    [Range(1, 999)]
    public int Quantity { get; set; }
}
