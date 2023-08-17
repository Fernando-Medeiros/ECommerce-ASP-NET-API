namespace ECommerce.Modules.Category;

using ECommerce.Exceptions;
using ECommerce.Modules.Product;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryDTO?>> FindMany(CategoryQueryDTO query)
    {
        return await _repository.FindMany(query);
    }

    public async Task<IEnumerable<ProductDTO?>> FindProducts(string productId)
    {
        return await _repository.FindProducts(productId);
    }

    public async Task<CategoryDTO> FindOne(
        string? categoryId = null, string? name = null)
    {
        return await _repository.FindOne(categoryId, name)
            ?? throw new NotFoundError("Category Not Found");
    }

    public async Task Register(CategoryCreateDTO dto)
    {
        await CategoryExists(name: dto.Name);

        await _repository.Create(dto);
    }

    public async Task Update(CategoryUpdateDTO dto)
    {
        await CategoryExists(name: dto.Name);

        CategoryDTO category = await FindOne(dto.Id);

        dto.UpdateProperties(ref category);

        await _repository.Update(category);
    }

    public async Task Remove(string categoryId)
    {
        CategoryDTO category = await FindOne(categoryId);

        await _repository.Remove(category);
    }

    private async Task CategoryExists(string? id = null, string? name = null)
    {
        if (await _repository.FindOne(id, name) != null)
            throw new BadRequestError("Category is already exist");
    }
}