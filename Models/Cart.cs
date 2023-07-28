namespace ECommerce_ASP_NET_API.Models;

public class Cart
{
    public int Id { get; set; }
    public string? ProductId { get; set; }
    public int Quantity { get; set; }
    public Customer? Customer { get; set; }
    public DateTime CreatedAt { get; set; }
}
