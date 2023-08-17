namespace ECommerce.Modules.Category;

using System.ComponentModel.DataAnnotations;

public class CategoryUpdateRequest
{
    private string? _name;

    [MinLength(3), MaxLength(100)]
    public string? Name
    {
        get => _name;
        set => _name = value?.Trim().ToLower();
    }
}
