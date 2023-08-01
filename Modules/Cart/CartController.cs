namespace ECommerce_ASP_NET_API.Modules.Cart;

using ECommerce_ASP_NET_API.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/carts", Name = "Cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _service;
    public CartController(ICartService service) => _service = service;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CartDTO>> FindOne(int id)
    {
        var cart = await _service.FindOne(id)
            ?? throw new NotFoundError("Cart Not Found");

        return Ok(cart);
    }

    [HttpPost]
    public async Task<ActionResult<CartDTO>> Register(
        [FromBody] CartCreateDTO cartDto)
    {
        var cart = await _service.Register(cartDto);

        return Created(nameof(FindOne), cart);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult> Update(
        int id, [FromBody] CartUpdateDTO cartDto)
    {
        cartDto.Id = id;

        await _service.Update(cartDto);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
        await _service.Remove(new() { Id = id });

        return NoContent();
    }
}
