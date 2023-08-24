using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Product;

[ApiController]
[Route("api/v1/products")]
public partial class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service) => _service = service;

    #region Public

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResource>>> FindMany(
        [FromQuery] ProductQueryDTO query)
    {
        IEnumerable<ProductResource> resources = ProductResource.ToArray(
            array: await _service.FindMany(query));

        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResource>> FindOne(string id)
    {
        ProductResource resource = new(await _service.FindOne(id));

        return Ok(resource);
    }

    #endregion

    #region Manager - Employee

    [HttpPost, Authorize(Roles = "manager, employee")]
    public async Task<ActionResult> Register(
        [FromBody] ProductCreateRequest request)
    {
        await _service.Register(
            dto: ProductCreateDTO.ExtractProperties(request));

        return Created("", null);
    }

    [HttpPatch("{id}"), Authorize(Roles = "manager, employee")]
    public async Task<ActionResult> Update(
        [FromBody] ProductUpdateRequest request, string id)
    {
        await _service.Update(
            dto: ProductUpdateDTO.ExtractProperties(request, id));

        return NoContent();
    }

    [HttpDelete("{id}"), Authorize(Roles = "manager, employee")]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(id);

        return NoContent();
    }

    #endregion
}