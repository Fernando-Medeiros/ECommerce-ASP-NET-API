namespace ECommerce.Modules.Product;

using AutoMapper;
using ECommerce.Exceptions;
using ECommerce.Models;
using ECommerce.Modules.Category;

public class ProductService : IProductService
{
    private readonly ICategoryService _categoryService;

    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public ProductService(
        ICategoryService categoryService,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _categoryService = categoryService;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> FindMany(ProductQueryDTO query)
    {
        var productEntities = await _productRepository.FindMany(query);

        return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
    }

    public async Task<ProductDTO> FindOne(int? id = null, string? name = null)
    {
        var productEntity = await _productRepository.FindOne(id, name)
            ?? throw new NotFoundError("Product Not Found");

        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task Register(ProductDTO Dto)
    {
        await ProductExists(name: Dto.Name);

        await _categoryService.FindOne(id: Dto.CategoryId);

        Dto.CreatedAt = DateTime.UtcNow;

        var productEntity = _mapper.Map<Product>(Dto);

        await _productRepository.Create(productEntity);
    }

    public async Task Update(ProductDTO Dto)
    {
        ProductDTO product = await FindOne(Dto.Id);

        if (Dto.Name != null)
        {
            await ProductExists(name: Dto.Name);

            product.Name = Dto.Name;
        }

        if (Dto.CategoryId != null)
        {
            await _categoryService.FindOne(Dto.CategoryId);

            product.CategoryId = (int)Dto.CategoryId;
        }

        if (Dto.Description != null)
            product.Description = Dto.Description;

        if (Dto.ImageURL != null)
            product.ImageURL = Dto.ImageURL;

        if (Dto.Price != null)
            product.Price = (decimal)Dto.Price;

        if (Dto.Stock != null)
            product.Stock = (long)Dto.Stock!;

        var productEntity = _mapper.Map<Product>(product);

        await _productRepository.Update(productEntity);
    }

    public async Task Remove(ProductDTO Dto)
    {
        ProductDTO product = await FindOne(Dto.Id);

        var productEntity = _mapper.Map<Product>(product);

        await _productRepository.Remove(productEntity);
    }


    private async Task ProductExists(int? id = null, string? name = null)
    {
        if (await _productRepository.FindOne(id, name) != null)
            throw new BadRequestError("Product is already exist");
    }
}