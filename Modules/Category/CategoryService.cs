namespace ECommerce_ASP_NET_API.Modules.Category;

using AutoMapper;
using ECommerce_ASP_NET_API.Models;
using ECommerce_ASP_NET_API.Modules.Category.Contracts;
using ECommerce_ASP_NET_API.Modules.Category.DTOs;
using Microsoft.EntityFrameworkCore;

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
        IQueryable<Category> queryBuilder = _repository.Find();

        if (query.Id) queryBuilder.OrderBy(c => c.Id);

        else if (query.Name) queryBuilder.OrderBy(c => c.Name);

        var categoryEntities = await _repository
            .Find()
            .AsNoTracking()
            .Take(query.Limit)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoryEntities);
    }

    public async Task<CategoryDTO> FindOne(int id)
    {
        var categoryEntity = await _repository
            .Find()
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);

        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task<CategoryDTO> Register(CategoryDTO categoryDto)
    {
        categoryDto.CreatedAt = DateTime.UtcNow;

        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _repository.Create(categoryEntity);

        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDto)
    {
        var currentCategory = await FindOne((int)categoryDto.Id!);

        currentCategory.Name = String.IsNullOrEmpty(categoryDto.Name)
            ? currentCategory.Name
            : categoryDto.Name;

        var categoryEntity = _mapper.Map<Category>(currentCategory);

        await _repository.Update(categoryEntity);
    }

    public async Task Remove(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);

        await _repository.Remove(categoryEntity);
    }
}