namespace ECommerce.Modules.Product;

using ECommerce.Models;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> FindMany(ProductQueryDTO query);

    public Task<Product?> FindOne(string? id = null, string? name = null);

    public Task Create(Product product);

    public Task Update(Product product);

    public Task Remove(Product product);
}

