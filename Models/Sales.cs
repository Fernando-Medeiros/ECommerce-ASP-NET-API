namespace ECommerce_ASP_NET_API.Models;

public class Sales
{
    public int Id { get; set; }
    public string? CustomerId { get; set; }
    public string? ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
}
