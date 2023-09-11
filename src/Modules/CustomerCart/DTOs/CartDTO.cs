namespace ECommerce.Modules.CustomerCart;

using ECommerce.Context.Models;

public class CartDTO
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }

    public int Quantity { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? CreatedAt { get; set; }

    public Customer? Customer { get; set; }
    public Product? Product { get; set; }
}
