namespace ECommerce_ASP_NET_API.Modules.Customer;

using ECommerce_ASP_NET_API.Exceptions;
using ECommerce_ASP_NET_API.Identities;
using ECommerce_ASP_NET_API.Modules.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers", Name = "Customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService service) => _service = service;

    [Authorize]
    [HttpGet("carts")]
    public async Task<ActionResult<IEnumerable<CartDTO>>> FindCarts()
    {
        CustomerIdentity customer = new(User);

        return Ok(await _service.FindCarts(customer.Id));
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<CustomerDTO>> Find()
    {
        CustomerIdentity customer = new(User);

        var customerDto = await _service.FindById(customer.Id)
            ?? throw new NotFoundError("Customer Not Found");

        return Ok(customerDto);
    }

    [HttpPost]
    public async Task<ActionResult> Register(
        [FromBody] CustomerCreateDTO customerDto)
    {
        await _service.Register(customerDto);

        return Created("", "");
    }

    [Authorize]
    [HttpPatch]
    public async Task<ActionResult> Update(
        [FromBody] CustomerUpdateDTO customerDto)
    {
        if (customerDto is null)
            throw new BadRequestError("Data is required");

        CustomerIdentity customer = new(User);

        customerDto.Id = customer.Id;

        await _service.Update(customerDto);

        return NoContent();
    }

    [Authorize]
    [HttpDelete]
    public async Task<ActionResult> Remove()
    {
        CustomerIdentity customer = new(User);

        await _service.Remove(new() { Id = customer.Id });

        return NoContent();
    }
}