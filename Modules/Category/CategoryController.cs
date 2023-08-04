namespace ECommerce.Modules.Category;

using ECommerce.Modules.Product;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categories", Name = "Categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> FindMany(
        [FromQuery] CategoryQueryDTO query)
    {
        return Ok(await _service.FindMany(query));
    }

    [HttpGet("{id:int}/products")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> FindProducts(int id)
    {
        return Ok(await _service.FindProducts(id));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> FindOne(int id)
    {
        return Ok(await _service.FindOne(id));
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] CategoryCreateDTO Dto)
    {
        await _service.Register(new()
        {
            Name = Dto.Name,
        });

        return Created("", "");
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update(
        int id,
        [FromBody] CategoryUpdateDTO Dto)
    {
        await _service.Update(new()
        {
            Id = id,
            Name = Dto.Name,
        });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}