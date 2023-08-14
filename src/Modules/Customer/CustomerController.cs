namespace ECommerce.Modules.Customer;

using ECommerce.Identities;
using ECommerce.Modules.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController, Authorize]
[Route("api/customers", Name = "Customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service) => _service = service;

    [HttpGet("carts")]
    public async Task<ActionResult<IEnumerable<CartDTO>>> FindCarts()
    {
        CustomerIdentity customer = new(User);

        return Ok(await _service.FindCarts(customer.Id));
    }

    [HttpGet]
    public async Task<ActionResult<CustomerDTO>> Find()
    {
        CustomerIdentity customer = new(User);

        return Ok(await _service.FindById(customer.Id));
    }

    [AllowAnonymous]
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

    [HttpDelete]
    public async Task<ActionResult> Remove()
    {
        CustomerIdentity customer = new(User);

        await _service.Remove(new() { Id = customer.Id });

        return NoContent();
    }
}