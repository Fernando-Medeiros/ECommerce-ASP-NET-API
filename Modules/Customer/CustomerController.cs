namespace ECommerce_ASP_NET_API.Modules.Customer;

using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Modules.Cart;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers", Name = "Customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service) => _service = service;

    [HttpGet("carts")]
    public async Task<ActionResult<IEnumerable<CartDTO>>> FindCarts(
        [FromQuery] CustomerQueryDTO query)
    {
        return Ok(await _service.FindCarts(query.Id!));
    }

    [HttpGet]
    public async Task<ActionResult<CustomerDTO>> Find(
        [FromQuery] CustomerQueryDTO query)
    {
        var customer = await _service.FindById(query.Id!)
            ?? throw new NotFoundError("Customer Not Found");

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> Register(
        [FromBody] CustomerCreateDTO customerDto)
    {
        var customer = await _service.Register(customerDto);

        return Created(nameof(Find), customer);
    }

    [HttpPatch]
    public async Task<ActionResult> Update(
        [FromQuery] CustomerQueryDTO query,
        [FromBody] CustomerUpdateDTO customerDto)
    {
        if (customerDto is null)
            throw new BadRequestError("Data is required");

        customerDto.Id = query.Id;

        await _service.Update(customerDto);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Remove(
        [FromQuery] CustomerQueryDTO query)
    {
        await _service.Remove(new() { Id = query.Id });

        return NoContent();
    }
}