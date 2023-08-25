using ECommerce.Identities;
using ECommerce.Startup.SwaggerProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.CustomerCart;

[ApiController, Authorize, Route("api/v1/carts")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class CustomerCartController : ControllerBase
{
    private readonly ICustomerCartService _service;

    public CustomerCartController(
        ICustomerCartService service) => _service = service;


    [HttpGet]
    [Success(typeof(IEnumerable<CartResource>))]
    public async Task<ActionResult> FindCarts()
    {
        CustomerIdentity customer = new(User);

        IEnumerable<CartDTO?> carts = await _service.FindCarts(customer.Id);

        IEnumerable<CartResource> resources = CartResource.ToArray(
            array: carts);

        return Ok(resources);
    }

    [HttpGet("{id}")]
    [Success(typeof(CartResource))]
    public async Task<ActionResult> FindOne(string id)
    {
        CustomerIdentity customer = new(User);

        CartDTO cart = await _service.FindOne(id, customer.Id);

        CartResource resource = new(cart);

        return Ok(resource);
    }

    [HttpPost]
    [Created(typeof(Nullable))]
    public async Task<ActionResult> Register(
        [FromBody] CartCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _service.Register(
            CartCreateDTO.ExtractProperties(request, customer.Id));

        return Created("", null);
    }

    [HttpPatch("{id}")]
    [NoContent]
    public async Task<ActionResult> Update(
        [FromBody] CartUpdateRequest request,
        string id)
    {
        CustomerIdentity customer = new(User);

        await _service.Update(
            CartUpdateDTO.ExtractProperties(request, id, customer.Id));

        return NoContent();
    }

    [HttpDelete("{id}")]
    [NoContent]
    public async Task<ActionResult> Remove(string id)
    {
        CustomerIdentity customer = new(User);

        await _service.Remove(id, customer.Id);

        return NoContent();
    }
}