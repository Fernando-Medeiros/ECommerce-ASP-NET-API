using ECommerce.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.CustomerAddress;

[ApiController, Authorize]
[Route("api/addresses")]
public class CustomerAddressController : ControllerBase
{
    private readonly ICustomerAddressService _addressService;

    public CustomerAddressController(ICustomerAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressResource>>> FindAddresses()
    {
        CustomerIdentity customer = new(User);

        IEnumerable<AddressResource> resources = AddressResource.ToArray(
            array: await _addressService.FindAddresses(customer.Id));

        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressResource>> FindAddress(string id)
    {
        CustomerIdentity customer = new(User);

        AddressResource resource = new(
            await _addressService.FindOne(id, customer.Id));

        return Ok(resource);
    }

    [HttpPost]
    public async Task<ActionResult> RegisterAddress(
        [FromBody] AddressCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Register(
            dto: AddressCreateDTO.ExtractProperties(request, customer.Id)
        );

        return Created("", null);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateAddress(
        [FromBody] AddressUpdateRequest request, string id)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Update(
            dto: AddressUpdateDTO.ExtractProperties(request, id, customer.Id)
        );

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveAddress(string id)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Remove(id, customer.Id);

        return NoContent();
    }
}
