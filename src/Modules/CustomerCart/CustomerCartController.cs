using ECommerce.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.CustomerCart;

[ApiController, Authorize]
[Route("api/carts")]
public class CustomerCartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CustomerCartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartResource>>> FindCarts()
    {
        CustomerIdentity customer = new(User);

        IEnumerable<CartResource> resources = CartResource.ToArray(
            array: await _cartService.FindCarts(customer.Id)
        );

        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CartResource>> FindOne(string id)
    {
        CustomerIdentity customer = new(User);

        CartResource resource = new(
            await _cartService.FindOne(id, customer.Id));

        return Ok(resource);
    }

    [HttpPost]
    public async Task<ActionResult> Register(
        [FromBody] CartCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _cartService.Register(
            CartCreateDTO.ExtractProperties(request, customer.Id));

        return Created("", null);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Update(
        [FromBody] CartUpdateRequest request,
        string id)
    {
        CustomerIdentity customer = new(User);

        await _cartService.Update(
            CartUpdateDTO.ExtractProperties(request, id, customer.Id));

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(string id)
    {
        CustomerIdentity customer = new(User);

        await _cartService.Remove(id, customer.Id);

        return NoContent();
    }
}