using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Product;

public class ProductUpdateRequest
{
    private string? _name;
    private string? _description;
    private string? _imageURL;
    private string? _categoryId;

    [MinLength(3), MaxLength(100)]
    public string? Name
    {
        get => _name;
        set => _name = value?.Trim().ToLower();
    }

    [MinLength(5), MaxLength(255)]
    public string? Description
    {
        get => _description;
        set => _description = value?.Trim().ToLower();
    }

    [MinLength(5), MaxLength(255)]
    public string? ImageURL
    {
        get => _imageURL;
        set => _imageURL = value?.Trim();
    }

    public decimal? Price { get; set; }

    [Range(1, 9999)]
    public long? Stock { get; set; }

    [MinLength(36), MaxLength(36)]
    public string? CategoryId
    {
        get => _categoryId;
        set => _categoryId = value?.Trim();
    }
}
