using System.ComponentModel.DataAnnotations;

namespace ECommerce.Modules.Category;

public class CategoryCreateRequest
{
    private string? _name;

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3), MaxLength(100)]
    public string? Name
    {
        get => _name;
        set => _name = value?.Trim().ToLower();
    }
}
