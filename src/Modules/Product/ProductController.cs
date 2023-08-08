namespace ECommerce.Modules.Product;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products", Name = "Product")]
public partial class ProductController : ControllerBase
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
        return Ok(await _service.FindOne(id));
    }
}

public partial class ProductController
{
    [Authorize(Roles = "manager, employee")]
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] ProductCreateDTO dto)
    {
        await _service.Register(new()
        {
            Name = dto.Name,
            ImageURL = dto.ImageURL,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            CategoryId = dto.CategoryId
        });

        return Created("", "");
    }

    [Authorize(Roles = "manager, employee")]
    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProductUpdateDTO dto)
    {
        await _service.Update(new()
        {
            Id = id,
            Name = dto.Name,
            ImageURL = dto.ImageURL,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock,
            CategoryId = dto.CategoryId
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