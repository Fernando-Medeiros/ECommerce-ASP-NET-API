namespace ECommerce.Context.Models;

public class Sales
{
    public string? Id { get; set; }
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
