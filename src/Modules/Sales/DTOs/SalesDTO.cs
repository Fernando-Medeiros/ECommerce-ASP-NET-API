namespace ECommerce.Modules.Sales;

public class SalesDTO
{
    public virtual string? Id { get; set; }

    public virtual string? CustomerId { get; set; }

    public virtual string? ProductId { get; set; }

    public virtual decimal? Price { get; set; }

    public virtual int? Quantity { get; set; }

    public virtual DateTime? UpdatedAt { get; set; }

    public virtual DateTime? CreatedAt { get; set; }
}
