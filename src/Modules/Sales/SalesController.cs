namespace ECommerce.Modules.Sales;

using ECommerce.Modules.Sales.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize(Roles = "manager")]
[Route("api/sales", Name = "Sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;

    public SalesController(ISalesService service) => _service = service;

    [HttpGet("find-many")]
    public async Task<ActionResult<IEnumerable<SalesDTO>>> FindMany(
        [FromQuery] SalesQueryDTO query)
    {
        return Ok(await _service.FindMany(query));
    }

    [HttpGet("find-one")]
    public async Task<ActionResult<SalesDTO>> FindOne(
        [FromQuery] SalesQueryFindOneDTO query)
    {
        return Ok(await _service.FindOne(query));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesDTO>> FindById(string id)
    {
        return Ok(await _service.FindById(id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}
