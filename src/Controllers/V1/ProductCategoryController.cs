using ECommerce.Modules.Product;
using ECommerce.Startup.SwaggerProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.ProductCategory;

[ApiController, Route("api/v1/categories")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _service;

    public ProductCategoryController(
        IProductCategoryService service) => _service = service;

    #region Public

    [HttpGet]
    [Success(typeof(IEnumerable<CategoryResource>))]
    public async Task<ActionResult> FindMany(
        [FromQuery] CategoryQueryDTO query)
    {
        IEnumerable<CategoryDTO?> categories = await _service.FindMany(query);

        IEnumerable<CategoryResource> resources = CategoryResource
            .ToArray(array: categories);

        return Ok(resources);
    }

    [HttpGet("{id}/products")]
    [Success(typeof(IEnumerable<ProductResource>))]
    public async Task<ActionResult> FindProducts(string id)
    {
        IEnumerable<ProductDTO?> products = await _service.FindProducts(id);

        IEnumerable<ProductResource> resources = ProductResource.ToArray(
            array: products);

        return Ok(resources);
    }

    [HttpGet("{id}")]
    [Success(typeof(CategoryResource))]
    public async Task<ActionResult> FindOne(string id)
    {
        CategoryDTO category = await _service.FindOne(id);

        CategoryResource resource = new(category);

        return Ok(resource);
    }

    #endregion

    #region Manager - Employee

    [HttpPost, Authorize(Roles = "manager, employee")]
    [Created(typeof(Nullable))]
    public async Task<ActionResult> Register(
        [FromBody] CategoryCreateRequest request)
    {
        await _service.Register(
            dto: CategoryCreateDTO.ExtractProperties(request)
        );

        return Created("", null);
    }

    [HttpPatch("{id}"), Authorize(Roles = "manager, employee")]
    [NoContent]
    public async Task<ActionResult> Update(
        [FromBody] CategoryUpdateRequest request, string id)
    {
        await _service.Update(
            dto: CategoryUpdateDTO.ExtractProperties(request, id)
        );

        return NoContent();
    }

    [HttpDelete("{id}"), Authorize(Roles = "manager, employee")]
    [NoContent]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(id);

        return NoContent();
    }

    #endregion
}