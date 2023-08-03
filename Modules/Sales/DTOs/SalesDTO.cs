using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Sales;

public class SalesDTO
{
    public virtual int? Id { get; set; }

    [MinLength(36), MaxLength(36)]
    public virtual string? CustomerId { get; set; }

    public virtual int? ProductId { get; set; }

    public virtual decimal? Price { get; set; }

    [Range(1, 999)]
    public virtual int? Quantity { get; set; }

    public virtual DateTime? CreatedAt { get; set; }
}
