using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.CustomerCart;

public class CartCreateRequest
{
    public string? _productId;

    [Required(ErrorMessage = "The Product is Required")]
    [MinLength(36), MaxLength(36)]
    public string? ProductId
    {
        get => _productId;
        set => _productId = value?.Trim();
    }

    [Required(ErrorMessage = "The Quantity is Required")]
    [Range(1, 999)]
    public int Quantity { get; set; }
}