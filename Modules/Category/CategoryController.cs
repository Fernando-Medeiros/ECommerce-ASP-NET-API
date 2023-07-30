namespace ECommerce_ASP_NET_API.Modules.Category;

using ECommerce_ASP_NET_API.Modules.Category.Contracts;
using ECommerce_ASP_NET_API.Modules.Category.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categories", Name = "Categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service) => _service = service;

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> FindMany(
        [FromQuery] CategoryQueryDTO query)
    {
        return Ok(await _service.FindMany(query));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> FindOne(int id)
    {
        var category = await _service.FindOne(id);

        if (category is null) return NotFound("Category Not Found");

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Register(
            [FromBody] CategoryCreateDTO categoryDto)
    {
        var newCategory = await _service.Register(categoryDto);

        return Ok(newCategory);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update(
            int id, [FromBody] CategoryUpdateDTO categoryDto)
    {
        if (categoryDto is null) return BadRequest("Data is required");

        categoryDto.Id = id;

        await _service.Update(categoryDto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        var category = await _service.FindOne(id);

        if (category is null) return NotFound("Category Not Found");

        await _service.Remove(category);

        return NoContent();
    }
}