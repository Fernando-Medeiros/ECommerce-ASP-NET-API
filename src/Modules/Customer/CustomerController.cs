namespace ECommerce.Modules.Customer;

using ECommerce.Identities;
using ECommerce.Modules.Cart;
using ECommerce.Modules.CustomerAddress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController, Authorize]
[Route("api/customers", Name = "Customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    private readonly IAddressService _addressService;

    public CustomerController(
        ICustomerService service,
        IAddressService addressService
        )
    {
        _service = service;
        _addressService = addressService;
    }

    #region Owner

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

    #endregion

    #region Carts

    [HttpGet("carts")]
    public async Task<ActionResult<IEnumerable<CartDTO>>> FindCarts()
    {
        CustomerIdentity customer = new(User);

        return Ok(await _service.FindCarts(customer.Id));
    }

    #endregion

    #region Addresses

    [HttpGet("addresses")]
    public async Task<ActionResult<IEnumerable<AddressResource>>> FindAddresses()
    {
        CustomerIdentity customer = new(User);

        IEnumerable<AddressResource> resources = AddressResource.ToArray(
            array: await _addressService.FindAddresses(customer.Id));

        return Ok(resources);
    }

    [HttpGet("{id}/address")]
    public async Task<ActionResult<AddressResource>> FindAddress(string id)
    {
        CustomerIdentity customer = new(User);

        AddressResource resource = new(
            await _addressService.FindOne(id, customer.Id));

        return Ok(resource);
    }

    [HttpPost("address")]
    public async Task<ActionResult> RegisterAddress(
        [FromBody] AddressCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Register(
            dto: AddressCreateDTO.ExtractProprieties(request, customer.Id)
        );

        return Created("", null);
    }

    [HttpPatch("{id}/address")]
    public async Task<ActionResult> UpdateAddress(
        [FromBody] AddressUpdateRequest request, string id)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Update(
            dto: AddressUpdateDTO.ExtractProprieties(request, id, customer.Id)
        );

        return NoContent();
    }

    [HttpDelete("{id}/address")]
    public async Task<ActionResult> RemoveAddress(string id)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Remove(id, customer.Id);

        return NoContent();
    }

    #endregion

}