namespace ECommerce.Modules.Product;

public readonly struct ProductResource
{
    public readonly string? Id { get; init; }
    public readonly string? CategoryId { get; init; }
    public readonly string? Name { get; init; }
    public readonly string? Description { get; init; }
    public readonly string? ImageURL { get; init; }
    public readonly decimal Price { get; init; }
    public readonly long Stock { get; init; }
    public readonly DateOnly CreatedAt { get; init; }

    public ProductResource(ProductDTO _)
    {
        Id = _.Id;
        CategoryId = _.CategoryId;
        Name = _.Name;
        Description = _.Description;
        ImageURL = _.ImageURL;
        Price = (decimal)_.Price!;
        Stock = (long)_.Stock!;
        CreatedAt = DateOnly.FromDateTime(_.CreatedAt!.Value);
    }

    public static IEnumerable<ProductResource> ToArray(
        IEnumerable<ProductDTO?> array)
    {
        var carts = new List<ProductResource>();

        foreach (var dto in array)
            if (dto != null) carts.Add(new ProductResource(dto));

        return carts;
    }
}
