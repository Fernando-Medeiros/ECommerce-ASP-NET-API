namespace ECommerce_ASP_NET_API.Modules.Cart;

using System.ComponentModel.DataAnnotations;

public class CartUpdateDTO
{
    [Required(ErrorMessage = "The Quantity is Required")]
    [Range(1, 999)]
    public int Quantity { get; set; }
}
