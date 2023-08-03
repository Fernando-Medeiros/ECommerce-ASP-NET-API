namespace ECommerce.Modules.Product;

using ECommerce.Models;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> FindMany(ProductQueryDTO query);

    public Task<Product?> FindOne(int? id = null, string? name = null);

    public Task<Product> Create(Product product);

    public Task<Product> Update(Product product);

    public Task<Product> Remove(Product product);
}

