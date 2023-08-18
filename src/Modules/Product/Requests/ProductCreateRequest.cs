using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Product;

public class ProductCreateRequest
{
    private string? _name;
    private string? _description;
    private string? _imageURL;
    private string? _categoryId;

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3), MaxLength(100)]
    public string? Name
    {
        get => _name;
        set => _name = value?.Trim().ToLower();
    }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(5), MaxLength(255)]
    public string? Description
    {
        get => _description;
        set => _description = value?.Trim().ToLower();
    }

    [Required(ErrorMessage = "The ImageURL is Required")]
    [MinLength(5), MaxLength(255)]
    public string? ImageURL
    {
        get => _imageURL;
        set => _imageURL = value?.Trim();
    }

    [Required(ErrorMessage = "The Price is Required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is Required")]
    [Range(1, 9999)]
    public long Stock { get; set; }

    [Required(ErrorMessage = "The Category is Required")]
    [MinLength(36), MaxLength(36)]
    public string? CategoryId
    {
        get => _categoryId;
        set => _categoryId = value?.Trim();
    }
}
