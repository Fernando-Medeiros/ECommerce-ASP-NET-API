namespace ECommerce.Modules.Product;

using System.ComponentModel.DataAnnotations;

public class ProductUpdateDTO
{
    [MinLength(3), MaxLength(100)]
    public string? Name { get; set; }

    [MinLength(5), MaxLength(255)]
    public string? Description { get; set; }

    [MinLength(5), MaxLength(255)]
    public string? ImageURL { get; set; }

    public decimal? Price { get; set; }

    [Range(1, 9999)]
    public long? Stock { get; set; }

    public string? CategoryId { get; set; }
}
