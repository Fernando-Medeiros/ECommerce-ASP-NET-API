using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Cart;

public class CartUpdateRequest
{
    [Range(1, 999)]
    public int? Quantity { get; set; }
}