namespace ECommerce.Modules.Product;

public readonly struct ProductCreateDTO
{
    public readonly string? Id;
    public readonly string? CategoryId;
    public readonly string? Name;
    public readonly string? Description;
    public readonly string? ImageURL;
    public readonly decimal Price;
    public readonly long Stock;
    public readonly DateTime CreatedAt;

    public ProductCreateDTO(
        string? name,
        string? description,
        string? imageURL,
        decimal price,
        long stock,
        string? categoryId)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        ImageURL = imageURL;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        CreatedAt = DateTime.UtcNow;
    }

    public static ProductCreateDTO ExtractProperties(
        ProductCreateRequest req)
    {
        return new(
            name: req.Name,
            description: req.Description,
            imageURL: req.ImageURL,
            price: req.Price,
            stock: req.Stock,
            categoryId: req.CategoryId);
    }
}
