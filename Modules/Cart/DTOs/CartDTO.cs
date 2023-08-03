namespace ECommerce.Modules.Cart;

using System.Text.Json.Serialization;
using ECommerce.Models;

public class CartDTO
{
    public virtual int Id { get; set; }

    public virtual string? CustomerId { get; set; }

    public virtual int ProductId { get; set; }

    public virtual int Quantity { get; set; }

    public virtual DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public virtual Customer? Customer { get; set; }
}
