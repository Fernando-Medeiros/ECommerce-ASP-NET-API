namespace ECommerce.Modules.Category;

public class CategoryUpdateDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static CategoryUpdateDTO ExtractProprieties(
        CategoryUpdateRequest _, string categoryId)
    {
        return new()
        {
            Id = categoryId,
            Name = _.Name,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    public void UpdateProperties(ref CategoryDTO category)
    {
        if (Name != null) category.Name = Name;

        category.UpdatedAt = UpdatedAt;
    }
}
