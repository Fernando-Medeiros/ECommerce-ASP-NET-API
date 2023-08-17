namespace ECommerce.Modules.Product;

using ECommerce.Exceptions;
using ECommerce.Modules.Category;

public class ProductService : IProductService
{
    private readonly ICategoryService _categoryService;

    private readonly IProductRepository _productRepository;

    public ProductService(
        ICategoryService categoryService,
        IProductRepository productRepository)
    {
        _categoryService = categoryService;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO?>> FindMany(ProductQueryDTO query)
    {
        return await _productRepository.FindMany(query);
    }

    public async Task<ProductDTO> FindOne(string? id = null, string? name = null)
    {
        return await _productRepository.FindOne(id, name)
            ?? throw new NotFoundError("Product Not Found");
    }

    public async Task Register(ProductCreateDTO Dto)
    {
        await ProductExists(name: Dto.Name);

        await _categoryService.FindOne(id: Dto.CategoryId);

        await _productRepository.Register(Dto);
    }

    public async Task Update(ProductUpdateDTO dto)
    {
        if (dto.Name != null)
            await ProductExists(name: dto.Name);

        if (dto.CategoryId != null)
            await _categoryService.FindOne(dto.CategoryId);

        ProductDTO product = await FindOne(dto.Id);

        dto.UpdateProperties(ref product);

        await _productRepository.Update(product);
    }

    public async Task Remove(string id)
    {
        ProductDTO product = await FindOne(id);

        await _productRepository.Remove(product);
    }


    private async Task ProductExists(string? id = null, string? name = null)
    {
        if (await _productRepository.FindOne(id, name) != null)
            throw new BadRequestError("Product is already exist");
    }
}