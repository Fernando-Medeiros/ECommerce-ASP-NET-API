namespace ECommerce.Modules.Product;

public class ProductUpdateDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public decimal? Price { get; set; }
    public long? Stock { get; set; }
    public string? CategoryId { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static ProductUpdateDTO ExtractProperties(
        ProductUpdateRequest _, string productId)
    {
        return new()
        {
            Id = productId,
            Name = _.Name,
            Description = _.Description,
            ImageURL = _.ImageURL,
            Price = _.Price,
            Stock = _.Stock,
            CategoryId = _.CategoryId,
            UpdatedAt = DateTime.UtcNow
        };
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
