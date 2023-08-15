namespace ECommerce.Modules.Cart;

using ECommerce.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController, Authorize]
[Route("api/carts", Name = "Cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _service;

    public CartController(ICartService service) => _service = service;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartDTO>> FindOne(int id)
    {
        CustomerIdentity customer = new(User);

        return Ok(await _service.FindOne(id, customer.Id));
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] CartCreateDTO Dto)
    {
        CustomerIdentity customer = new(User);

        await _service.Register(new()
        {
            CustomerId = customer.Id,
            ProductId = Dto.ProductId,
            Quantity = Dto.Quantity
        });

        return Created("", "");
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CartUpdateDTO Dto)
    {
        CustomerIdentity customer = new(User);

        await _service.Update(new()
        {
            Id = id,
            CustomerId = customer.Id,
            Quantity = Dto.Quantity
        });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        CustomerIdentity customer = new(User);

        await _service.Remove(new()
        {
            Id = id,
            CustomerId = customer.Id
        });

        return NoContent();
    }
}
