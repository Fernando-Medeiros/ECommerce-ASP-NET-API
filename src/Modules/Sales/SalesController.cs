using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Sales;

[ApiController]
[Authorize(Roles = "manager")]
[Route("api/sales", Name = "Sales")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;

    public SalesController(ISalesService service) => _service = service;

    [HttpGet("find-many")]
    public async Task<ActionResult<IEnumerable<SalesResource>>> FindMany(
        [FromQuery] SalesQueryDTO query)
    {
        IEnumerable<SalesResource> resources = SalesResource.ToArray(
            array: await _service.FindMany(query));

        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesResource>> FindById(string id)
    {
        SalesResource resource = new(await _service.FindById(id));

        return Ok(resource);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(id);

        return NoContent();
    }
}
