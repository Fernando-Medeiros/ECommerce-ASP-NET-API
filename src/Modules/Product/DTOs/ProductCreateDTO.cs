namespace ECommerce.Modules.Product;

using System.ComponentModel.DataAnnotations;

public class ProductCreateDTO
{
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3), MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5), MaxLength(255)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The ImageURL is Required")]
    [MinLength(5), MaxLength(255)]
    public string? ImageURL { get; set; }

    [Required(ErrorMessage = "The Price is Required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    public long Stock { get; set; }

    [Required(ErrorMessage = "The Category is Required")]
    public string? CategoryId { get; set; }
}
