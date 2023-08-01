namespace ECommerce_ASP_NET_API.Modules.Product;

using AutoMapper;
using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Modules.Category;

public class ProductService : IProductService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    public ProductService(
        ICategoryRepository categoryRepository,
        IProductRepository repository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> FindMany(ProductQueryDTO query)
    {
        var productEntities = await _repository.FindMany(query);

        return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
    }

    public async Task<ProductDTO> FindOne(int? id = null, string? name = null)
    {
        var productEntity = await _repository.FindOne(id, name);

        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task<ProductDTO> Register(ProductDTO Dto)
    {
        if (await ProductExists(name: Dto.Name))
            throw new BadRequestError("Product is already exist");

        var _ = await _categoryRepository.FindOne(Dto.CategoryId)
            ?? throw new NotFoundError("Category Not Found");

        Dto.CreatedAt = DateTime.UtcNow;

        var productEntity = _mapper.Map<Product>(Dto);

        await _repository.Create(productEntity);

        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task Update(ProductDTO Dto)
    {
        var currentProductEntity = await _repository.FindOne(Dto.Id)
            ?? throw new NotFoundError("Product Not Found");

        if (Dto.Name != null)
        {
            if (await ProductExists(name: Dto.Name))
                throw new BadRequestError("Product is already exist");

            currentProductEntity.Name = Dto.Name;
        }

        if (Dto.CategoryId != null)
        {
            var _ = await _categoryRepository.FindOne(Dto.CategoryId)
                ?? throw new NotFoundError("Category Not Found");

            currentProductEntity.CategoryId = (int)Dto.CategoryId;
        }

        if (Dto.Description != null)
            currentProductEntity.Description = Dto.Description;

        if (Dto.ImageURL != null)
            currentProductEntity.ImageURL = Dto.ImageURL;

        if (Dto.Price != null)
            currentProductEntity.Price = (decimal)Dto.Price;

        if (Dto.Stock != null)
            currentProductEntity.Stock = (long)Dto.Stock!;

        await _repository.Update(currentProductEntity);
    }

    public async Task Remove(ProductDTO Dto)
    {
        var productEntity = await _repository.FindOne(Dto.Id)
            ?? throw new NotFoundError("Product Not Found");

        await _repository.Remove(productEntity);
    }


    private async Task<bool> ProductExists(int? id = null, string? name = null)
    {
        return await _repository.FindOne(id, name) != null;
    }
}