namespace ECommerce_ASP_NET_API.Modules.Customer;

using ECommerce_ASP_NET_API.Modules.Customer.Contracts;
using ECommerce_ASP_NET_API.Modules.Customer.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]", Name = "customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<CustomerDTO>> Get(
        [FromQuery] CustomerQueryDTO query)
    {
        var customer = await _service.FindById(query.Id!);

        if (customer is null) return NotFound("Id Not Found");

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> Register(
        [FromBody] CustomerCreateDTO customerDto)
    {
        var customer = await _service.Register(customerDto);

        return Created(nameof(Get), customer);
    }

    [HttpPatch]
    public async Task<ActionResult> Update(
        [FromQuery] CustomerQueryDTO query,
        [FromBody] CustomerUpdateDTO customerDto)
    {
        if (customerDto is null) return BadRequest("Data is required");

        customerDto.Id = query.Id;

        await _service.Update(customerDto);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] CustomerQueryDTO query)
    {
        var customer = await _service.FindById(query.Id!);

        if (customer is null) return NotFound("Id Not Found");

        await _service.Remove(customer);

        return NoContent();
    }
}