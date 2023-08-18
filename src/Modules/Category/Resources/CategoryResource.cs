namespace ECommerce.Modules.Category;

public struct CategoryResource
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateOnly CreatedAt { get; set; }

    public CategoryResource(CategoryDTO _)
    {
        Id = _.Id;
        Name = _.Name;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }

    public static IEnumerable<CategoryResource> ToArray(
        IEnumerable<CategoryDTO?> array)
    {
        var carts = new List<CategoryResource>();

        foreach (var dto in array)
            if (dto != null) carts.Add(new CategoryResource(dto));

        return carts;
    }
}
