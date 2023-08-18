namespace ECommerce.Modules.Category;

public readonly struct CategoryResource
{
    public readonly string? Id { get; init; }
    public readonly string? Name { get; init; }
    public readonly DateOnly CreatedAt { get; init; }

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
