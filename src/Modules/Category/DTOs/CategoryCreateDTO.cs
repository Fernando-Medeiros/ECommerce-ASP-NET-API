namespace ECommerce.Modules.Category;

public class CategoryCreateDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public static CategoryCreateDTO ExtractProprieties(
        CategoryCreateRequest _)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = _.Name,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
