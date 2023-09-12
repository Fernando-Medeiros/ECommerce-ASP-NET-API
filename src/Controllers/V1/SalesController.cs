using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Sales;

[ApiController, Authorize(Roles = "manager"), Route("api/v1/sales")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class SalesController : ControllerBase
{
    private readonly ISalesService _service;

    public SalesController(
        ISalesService service) => _service = service;

    [HttpGet("find-many")]
    [Success(typeof(IEnumerable<SalesResource>))]
    public async Task<ActionResult> FindMany(
        [FromQuery] SalesQueryDTO query)
    {
        IEnumerable<SalesDTO?> sales = await _service.FindMany(query);

        IEnumerable<SalesResource> resources = SalesResource.ToArray(
            array: sales);

        return Ok(resources);
    }

    [HttpGet("{id}")]
    [Success(typeof(SalesResource))]
    public async Task<ActionResult> FindById(string id)
    {
        SalesDTO sales = await _service.FindById(id);

        SalesResource resource = new(sales);

        return Ok(resource);
    }

    [HttpDelete("{id}")]
    [NoContent]
    public async Task<ActionResult> Remove(string id)
    {
        await _service.Remove(id);

        return NoContent();
    }
}
