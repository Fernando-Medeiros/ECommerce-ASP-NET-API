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
    public async Task<ActionResult<CustomerResource>> Find()
    {
        CustomerIdentity customer = new(User);

        CustomerResource resource = new(await _service.FindById(customer.Id));

        return Ok(resource);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register(
        [FromBody] CustomerCreateRequest request)
    {
        await _service.Register(
            dto: CustomerCreateDTO.ExtractProperties(request));

        return Created("", null);
    }

    [HttpPatch]
    public async Task<ActionResult> Update(
        [FromBody] CustomerUpdateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _service.Update(
            dto: CustomerUpdateDTO.ExtractProperties(request, customer.Id));

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Remove()
    {
        CustomerIdentity customer = new(User);

        await _service.Remove(id: customer.Id);

        return NoContent();
    }
}