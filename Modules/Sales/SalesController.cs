namespace ECommerce.Modules.Sales;

using Microsoft.AspNetCore.Mvc;

[Route("api/sales", Name = "Sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;

    public SalesController(ISalesService service) => _service = service;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SalesDTO>> Find(int id)
    {
        return Ok(await _service.Find(id));
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] SalesCreateDTO dto)
    {
        await _service.Register(new()
        {
            CustomerId = dto.CustomerId,
            ProductId = dto.ProductId,
            Price = dto.Price,
            Quantity = dto.Quantity,
        });

        return Created("", "");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}
