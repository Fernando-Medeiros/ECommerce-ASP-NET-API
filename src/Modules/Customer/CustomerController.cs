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
    private readonly IAddressService _addressService;

    private readonly ICartService _cartService;

    private readonly ICustomerService _customerService;

    public CustomerController(
        IAddressService addressService,
        ICartService cartService,
        ICustomerService customerService)
    {
        _addressService = addressService;
        _cartService = cartService;
        _customerService = customerService;
    }

    #region Owner

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

    #endregion

    #region Carts

    [HttpGet("carts")]
    public async Task<ActionResult<IEnumerable<CartResource>>> FindCarts()
    {
        CustomerIdentity customer = new(User);

        IEnumerable<CartResource> resources = CartResource.ToArray(
            array: await _customerService.FindCarts(customer.Id)
        );

        return Ok(resources);
    }

    [HttpGet("{id}/carts")]
    public async Task<ActionResult<CartResource>> FindOne(string id)
    {
        CustomerIdentity customer = new(User);

        CartResource resource = new(
            await _cartService.FindOne(id, customer.Id));

        return Ok(resource);
    }

    [HttpPost("carts")]
    public async Task<ActionResult> Register(
        [FromBody] CartCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _cartService.Register(
            CartCreateDTO.ExtractProprieties(request, customer.Id));

        return Created("", null);
    }

    [HttpPatch("{id}/carts")]
    public async Task<ActionResult> Update(
        [FromBody] CartUpdateRequest request,
        string id)
    {
        CustomerIdentity customer = new(User);

        await _cartService.Update(
            CartUpdateDTO.ExtractProprieties(request, id, customer.Id));

        return NoContent();
    }

    [HttpDelete("{id}/carts")]
    public async Task<ActionResult> Remove(string id)
    {
        CustomerIdentity customer = new(User);

        await _cartService.Remove(id, customer.Id);

        return NoContent();
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

    [HttpGet("{id}/addresses")]
    public async Task<ActionResult<AddressResource>> FindAddress(string id)
    {
        CustomerIdentity customer = new(User);

        AddressResource resource = new(
            await _addressService.FindOne(id, customer.Id));

        return Ok(resource);
    }

    [HttpPost("addresses")]
    public async Task<ActionResult> RegisterAddress(
        [FromBody] AddressCreateRequest request)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Register(
            dto: AddressCreateDTO.ExtractProprieties(request, customer.Id)
        );

        return Created("", null);
    }

    [HttpPatch("{id}/addresses")]
    public async Task<ActionResult> UpdateAddress(
        [FromBody] AddressUpdateRequest request, string id)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Update(
            dto: AddressUpdateDTO.ExtractProprieties(request, id, customer.Id)
        );

        return NoContent();
    }

    [HttpDelete("{id}/addresses")]
    public async Task<ActionResult> RemoveAddress(string id)
    {
        CustomerIdentity customer = new(User);

        await _addressService.Remove(id, customer.Id);

        return NoContent();
    }

    #endregion

}