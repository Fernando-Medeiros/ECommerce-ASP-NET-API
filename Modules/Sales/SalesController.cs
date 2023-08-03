namespace ECommerce.Modules.Sales;

using ECommerce.Exceptions;
using Microsoft.AspNetCore.Mvc;

[Route("api/sales", Name = "Sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;
    public SalesController(ISalesService service) => _service = service;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SalesDTO>> Find(int id)
    {
        var sales = await _service.Find(id)
            ?? throw new NotFoundError("Sales Not Found");

        return Ok(sales);
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] SalesCreateDTO salesDto)
    {
        await _service.Register(salesDto);

        return Created("", "");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}
