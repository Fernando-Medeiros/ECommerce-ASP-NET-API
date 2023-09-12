using ECommerce.Identities;
using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Customer;

[ApiController, Authorize, Route("api/v1/customers")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(
        ICustomerService service) => _service = service;

    [HttpGet]
    [Success(typeof(CustomerResource))]
    public async Task<ActionResult> FindOne()
    {
        CustomerIdentity customer = new(User);

        CustomerDTO customerDTO = await _service.FindById(customer.Id);

        CustomerResource resource = new(customerDTO);

        return Ok(resource);
    }

    [HttpPost, AllowAnonymous]
    [Created(typeof(Nullable))]
    public async Task<ActionResult> Register(
        [FromBody] CustomerCreateRequest request)
    {
        await _service.Register(
            dto: CustomerCreateDTO.ExtractProperties(request));

        return Created("", null);
    }

    [HttpPatch]
    [NoContent]
    public async Task<ActionResult> Update(
        [FromBody] CustomerUpdateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _service.Update(
            dto: CustomerUpdateDTO.ExtractProperties(request, customer.Id));

        return NoContent();
    }

    [HttpDelete]
    [NoContent]
    public async Task<ActionResult> Remove()
    {
        CustomerIdentity customer = new(User);

        await _service.Remove(id: customer.Id);

        return NoContent();
    }
}