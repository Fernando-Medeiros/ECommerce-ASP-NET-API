namespace ECommerce.Modules.Sales;

public class SalesDTO
{
    public virtual int? Id { get; set; }

    public virtual string? CustomerId { get; set; }

    public virtual int? ProductId { get; set; }

    public virtual decimal? Price { get; set; }

    public virtual int? Quantity { get; set; }

    public virtual DateTime? CreatedAt { get; set; }
}
