namespace ECommerce.Modules.Category;

using AutoMapper;
using ECommerce.Exceptions;
using ECommerce.Models;
using ECommerce.Modules.Product;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> FindMany(CategoryQueryDTO query)
    {
        var categoryEntities = await _repository.FindMany(query);

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntities);
    }

    public async Task<IEnumerable<ProductDTO>> FindProducts(int id)
    {
        var products = await _repository.FindProducts(id);

        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<CategoryDTO> FindOne(int? id = null, string? name = null)
    {
        var categoryEntity = await _repository.FindOne(id, name)
            ?? throw new NotFoundError("Category Not Found");

        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Register(CategoryDTO Dto)
    {
        await CategoryExists(name: Dto.Name);

        Dto.CreatedAt = DateTime.UtcNow;

        var categoryEntity = _mapper.Map<Category>(Dto);

        await _repository.Create(categoryEntity);
    }

    public async Task Update(CategoryDTO Dto)
    {
        await CategoryExists(name: Dto.Name);

        CategoryDTO categoryDto = await FindOne(Dto.Id);

        categoryDto.Name = Dto.Name;

        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _repository.Update(categoryEntity);
    }

    public async Task Remove(CategoryDTO Dto)
    {
        CategoryDTO categoryDto = await FindOne(Dto.Id);

        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _repository.Remove(categoryEntity);
    }

    private async Task CategoryExists(int? id = null, string? name = null)
    {
        if (await _repository.FindOne(id, name) != null)
            throw new BadRequestError("Category is already exist");
    }
}