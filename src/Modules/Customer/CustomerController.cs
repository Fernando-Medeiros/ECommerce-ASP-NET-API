namespace ECommerce.Modules.Customer;

using ECommerce.Identities;
using ECommerce.Modules.Cart;
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

        return Ok(await _service.FindById(customer.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] CustomerCreateDTO dto)
    {
        await _service.Register(new()
        {
            Name = dto.Name,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password
        });

        return Created("", "");
    }

    [Authorize]
    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] CustomerUpdateDTO dto)
    {
        CustomerIdentity customer = new(User);

        await _service.Update(new()
        {
            Id = customer.Id,
            Name = dto.Name,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        });

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