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

    #region Public

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResource>>> FindMany(
        [FromQuery] CategoryQueryDTO query)
    {
        IEnumerable<CategoryResource> resources = CategoryResource
            .ToArray(array: await _service.FindMany(query));

        return Ok(resources);
    }

    [HttpGet("{id}/products")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> FindProducts(string id)
    {
        return Ok(await _service.FindProducts(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryResource>> FindOne(string id)
    {
        CategoryResource resource = new(await _service.FindOne(id));

        return Ok(resource);
    }

    #endregion

    #region Manager - Employee

    [Authorize(Roles = "manager, employee")]
    [HttpPost]
    public async Task<ActionResult> Register(
        [FromBody] CategoryCreateRequest request)
    {
        await _service.Register(
            dto: CategoryCreateDTO.ExtractProprieties(request)
        );

        return Created("", null);
    }

    [Authorize(Roles = "manager, employee")]
    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(
        [FromBody] CategoryUpdateRequest request, string id)
    {
        await _service.Update(
            dto: CategoryUpdateDTO.ExtractProprieties(request, id)
        );

        return NoContent();
    }

    [Authorize(Roles = "manager, employee")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(id);

        return NoContent();
    }

    #endregion
}