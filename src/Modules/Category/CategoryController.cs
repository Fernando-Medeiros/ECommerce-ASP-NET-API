namespace ECommerce.Modules.Category;

using ECommerce.Modules.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categories", Name = "Categories")]
public partial class CategoryController : ControllerBase
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
}

public partial class CategoryController
{
    [Authorize(Roles = "manager, employee")]
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] CategoryCreateDTO Dto)
    {
        await _service.Register(new()
        {
            Name = Dto.Name,
        });

        return Created("", "");
    }

    [Authorize(Roles = "manager, employee")]
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

    [Authorize(Roles = "manager, employee")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}