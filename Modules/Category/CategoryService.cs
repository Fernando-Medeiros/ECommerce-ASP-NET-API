namespace ECommerce_ASP_NET_API.Modules.Category;

using AutoMapper;
using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Models;

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

    public async Task<CategoryDTO> FindOne(int id)
    {
        var categoryEntity = await _repository.FindOne(id);

        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task<CategoryDTO> Register(CategoryDTO categoryDto)
    {
        if (await CategoryExists(name: categoryDto.Name))
            throw new BadRequestError("Category is already exist");

        categoryDto.CreatedAt = DateTime.UtcNow;

        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _repository.Create(categoryEntity);

        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDto)
    {
        if (await CategoryExists(name: categoryDto.Name))
            throw new BadRequestError("Category is already exist");

        var currentCategoryEntity = await _repository.FindOne(id: categoryDto.Id)
            ?? throw new NotFoundError("Category Not Found");

        currentCategoryEntity.Name = categoryDto.Name;

        await _repository.Update(currentCategoryEntity);
    }

    public async Task Remove(CategoryDTO Dto)
    {
        var categoryEntity = await _repository.FindOne(id: Dto.Id)
            ?? throw new NotFoundError("Category Not Found");

        await _repository.Remove(categoryEntity);
    }

    private async Task<bool> CategoryExists(int? id = null, string? name = null)
    {
        return await _repository.FindOne(id, name) != null;
    }
}