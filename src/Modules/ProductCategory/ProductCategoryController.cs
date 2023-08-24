using ECommerce.Modules.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.ProductCategory;

[ApiController]
[Route("api/categories")]
public partial class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _service;

    public ProductCategoryController(IProductCategoryService service) => _service = service;

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
    public async Task<ActionResult<IEnumerable<ProductResource>>> FindProducts(string id)
    {
        IEnumerable<ProductResource> resources = ProductResource.ToArray(
            array: await _service.FindProducts(id));

        return Ok(resources);
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
            dto: CategoryCreateDTO.ExtractProperties(request)
        );

        return Created("", null);
    }

    [Authorize(Roles = "manager, employee")]
    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(
        [FromBody] CategoryUpdateRequest request, string id)
    {
        await _service.Update(
            dto: CategoryUpdateDTO.ExtractProperties(request, id)
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