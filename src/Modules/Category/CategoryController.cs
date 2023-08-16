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

    [HttpGet("{id}/products")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> FindProducts(string id)
    {
        return Ok(await _service.FindProducts(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> FindOne(string id)
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
    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(
        string id,
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
    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}