namespace ECommerce.Modules.Product;

using ECommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products", Name = "Product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    public ProductController(IProductService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> FindMany(
        [FromQuery] ProductQueryDTO query)
    {
        return Ok(await _service.FindMany(query));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDTO>> FindOne(int id)
    {
        var product = await _service.FindOne(id)
            ?? throw new NotFoundError("Product Not Found");

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Register(
        [FromBody] ProductCreateDTO productDto)
    {
        var product = await _service.Register(productDto);

        return Created(nameof(FindOne), product);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update(
        int id, [FromBody] ProductUpdateDTO productDto)
    {
        productDto.Id = id;

        await _service.Update(productDto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}