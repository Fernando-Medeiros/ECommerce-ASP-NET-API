namespace ECommerce.Modules.Category;

public readonly struct CategoryCreateDTO
{
    public readonly string? Id;
    public readonly string? Name;
    public readonly DateTime CreatedAt;

    public CategoryCreateDTO(string? name)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public static CategoryCreateDTO ExtractProperties(
        CategoryCreateRequest req)
    {
        return new(name: req.Name);
    }
}
