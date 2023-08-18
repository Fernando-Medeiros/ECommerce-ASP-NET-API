namespace ECommerce.Modules.Product;

public struct ProductResource
{
    public string? Id { get; set; }
    public string? CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public DateOnly CreatedAt { get; set; }

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
