using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Product;

[ApiController, Route("api/v1/products")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(
        IProductService service) => _service = service;

    #region Public

    [HttpGet]
    [Success(typeof(IEnumerable<ProductResource>))]
    public async Task<ActionResult> FindMany(
        [FromQuery] ProductQueryDTO query)
    {
        IEnumerable<ProductDTO?> products = await _service.FindMany(query);

        IEnumerable<ProductResource> resources = ProductResource.ToArray(
            array: products);

        return Ok(resources);
    }

    [HttpGet("{id}")]
    [Success(typeof(ProductResource))]
    public async Task<ActionResult> FindOne(string id)
    {
        ProductDTO product = await _service.FindOne(id);

        ProductResource resource = new(product);

        return Ok(resource);
    }

    #endregion

    #region Manager - Employee

    [HttpPost, Authorize(Roles = "manager, employee")]
    [Created(typeof(Nullable))]
    public async Task<ActionResult> Register(
        [FromBody] ProductCreateRequest request)
    {
        await _service.Register(
            dto: ProductCreateDTO.ExtractProperties(request));

        return Created("", null);
    }

    [HttpPatch("{id}"), Authorize(Roles = "manager, employee")]
    [NoContent]
    public async Task<ActionResult> Update(
        [FromBody] ProductUpdateRequest request, string id)
    {
        await _service.Update(
            dto: ProductUpdateDTO.ExtractProperties(request, id));

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