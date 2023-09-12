using ECommerce.Identities;
using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.CustomerAddress;

[ApiController, Authorize, Route("api/v1/addresses")]
[BadRequest, Unauthorized, Forbidden, NotFound]
public class CustomerAddressController : ControllerBase
{
    private readonly ICustomerAddressService _service;

    public CustomerAddressController(
        ICustomerAddressService service) => _service = service;

    [HttpGet]
    [Success(typeof(IEnumerable<AddressResource>))]
    public async Task<ActionResult> FindAddresses()
    {
        CustomerIdentity customer = new(User);

        IEnumerable<AddressDTO?> addresses = await _service.FindAddresses(
            customer.Id);

        IEnumerable<AddressResource> resources = AddressResource.ToArray(
            array: addresses);

        return Ok(resources);
    }

    [HttpGet("{id}")]
    [Success(typeof(AddressResource))]
    public async Task<ActionResult> FindOne(string id)
    {
        CustomerIdentity customer = new(User);

        AddressDTO address = await _service.FindOne(id, customer.Id);

        AddressResource resource = new(address);

        return Ok(resource);
    }

    [HttpPost]
    [Created(typeof(Nullable))]
    public async Task<ActionResult> Register(
        [FromBody] AddressCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _service.Register(
            dto: AddressCreateDTO.ExtractProperties(request, customer.Id)
        );

        return Created("", null);
    }

    [HttpPatch("{id}")]
    [NoContent]
    public async Task<ActionResult> Update(
        [FromBody] AddressUpdateRequest request, string id)
    {
        CustomerIdentity customer = new(User);

        await _service.Update(
            dto: AddressUpdateDTO.ExtractProperties(request, id, customer.Id)
        );

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
