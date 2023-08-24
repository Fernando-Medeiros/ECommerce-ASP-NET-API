namespace ECommerce.Modules.ProductCategory;

public readonly struct CategoryUpdateDTO
{
    public readonly string? Id;
    public readonly string? Name;
    public readonly DateTime UpdatedAt;

    public CategoryUpdateDTO(
        string? categoryId,
        string? name)
    {
        Id = categoryId;
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public static CategoryUpdateDTO ExtractProperties(
        CategoryUpdateRequest req, string categoryId)
    {
        return new(
            categoryId: categoryId,
            name: req.Name);
    }

    public readonly void UpdateProperties(ref CategoryDTO category)
    {
        if (Name != null) category.Name = Name;

        category.UpdatedAt = UpdatedAt;
    }
}
