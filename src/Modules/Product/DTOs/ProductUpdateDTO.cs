namespace ECommerce.Modules.Product;

public readonly struct ProductUpdateDTO
{
    public readonly string? Id;
    public readonly string? CategoryId;
    public readonly string? Name;
    public readonly string? Description;
    public readonly string? ImageURL;
    public readonly decimal? Price;
    public readonly long? Stock;
    public readonly DateTime UpdatedAt;

    public ProductUpdateDTO(
        string? id,
        string? name,
        string? description,
        string? imageURL,
        decimal? price,
        long? stock,
        string? categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageURL = imageURL;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        UpdatedAt = DateTime.UtcNow;
    }

    public static ProductUpdateDTO ExtractProperties(
        ProductUpdateRequest req, string productId)
    {
        return new(
            id: productId,
            name: req.Name,
            description: req.Description,
            imageURL: req.ImageURL,
            price: req.Price,
            stock: req.Stock,
            categoryId: req.CategoryId);
    }

    public void UpdateProperties(ref ProductDTO product)
    {
        if (Name != null) product.Name = Name;

        if (Description != null) product.Description = Description;

        if (ImageURL != null) product.ImageURL = ImageURL;

        if (Price != null) product.Price = Price;

        if (Stock != null) product.Stock = Stock;

        if (CategoryId != null) product.CategoryId = CategoryId;

        product.UpdatedAt = UpdatedAt;
    }
}
