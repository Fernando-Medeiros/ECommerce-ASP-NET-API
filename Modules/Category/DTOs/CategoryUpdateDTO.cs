namespace ECommerce.Modules.Category;

using System.ComponentModel.DataAnnotations;

public class CategoryUpdateDTO
{
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3), MaxLength(100)]
    public string? Name { get; set; }
}
