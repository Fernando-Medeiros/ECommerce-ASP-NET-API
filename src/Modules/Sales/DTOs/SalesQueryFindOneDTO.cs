namespace ECommerce.Modules.Sales.DTOs;

using System.ComponentModel.DataAnnotations;

public class SalesQueryFindOneDTO
{
    [Required]
    public int ProductId { get; set; }

    [Required, MinLength(36), MaxLength(36)]
    public string? CustomerId { get; set; }

    [Required, DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
}
