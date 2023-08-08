namespace ECommerce.Modules.Cart;

using System.Text.Json.Serialization;
using ECommerce.Models;

public class CartDTO
{
    public int Id { get; set; }

    public string? CustomerId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public Customer? Customer { get; set; }

    [JsonIgnore]
    public Product? Product { get; set; }
}
