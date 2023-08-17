namespace ECommerce.Modules.Product;

public class ProductCreateDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageURL { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public string? CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }

    public static ProductCreateDTO ExtractProperties(
        ProductCreateRequest _)
    {
        return new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = _.Name,
            Description = _.Description,
            ImageURL = _.ImageURL,
            Price = _.Price,
            Stock = _.Stock,
            CategoryId = _.CategoryId,
            CreatedAt = DateTime.UtcNow
        };
    }
}
