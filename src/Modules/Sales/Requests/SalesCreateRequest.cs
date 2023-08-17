using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Sales;

public class SalesCreateRequest
{
    private string? _customerId;
    private string? _productId;


    [Required(ErrorMessage = "The CustomerId is Required")]
    [MinLength(36), MaxLength(36)]
    public string? CustomerId
    {
        get => _customerId;
        set => _customerId = value?.Trim();
    }

    [Required(ErrorMessage = "The ProductId is Required")]
    [MinLength(36), MaxLength(36)]
    public string? ProductId
    {
        get => _productId;
        set => _productId = value?.Trim();
    }

    [Required(ErrorMessage = "The Price is Required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    [Range(1, 999)]
    public int Quantity { get; set; }
}
