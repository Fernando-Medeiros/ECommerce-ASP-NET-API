using ECommerce.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Customer;

[ApiController, Authorize]
[Route("api/v1/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<CustomerResource>> Find()
    {
        CustomerIdentity customer = new(User);

        CustomerResource resource = new(await _customerService.FindById(customer.Id));

        return Ok(resource);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register(
        [FromBody] CustomerCreateRequest request)
    {
        await _customerService.Register(
            dto: CustomerCreateDTO.ExtractProperties(request));

        return Created("", null);
    }

    [HttpPatch]
    public async Task<ActionResult> Update(
        [FromBody] CustomerUpdateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _customerService.Update(
            dto: CustomerUpdateDTO.ExtractProperties(request, customer.Id));

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Remove()
    {
        CustomerIdentity customer = new(User);

        await _customerService.Remove(id: customer.Id);

        return NoContent();
    }
}