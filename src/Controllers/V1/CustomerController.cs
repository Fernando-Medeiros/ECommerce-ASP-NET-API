using AutoMapper;
using ECommerce.Events.Mail;
using ECommerce.Identities;
using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Customer;

[ApiController, Authorize]
[Route("api/v1/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [NotFound, Unauthorized, Forbidden]
    [Success(typeof(CustomerResource))]
    public async Task<ActionResult> FindOne()
    {
        var customer = new CustomerIdentity(User);

        var customerDTO = await new FindOneCustomer(_repository)
            .Execute(new() { Id = customer.Id });

        var resource = new CustomerResource(customerDTO);

        return Ok(resource);
    }

    [HttpPost, AllowAnonymous]
    [Created, BadRequest]
    public async Task<ActionResult> Register(
        [FromServices] IMapper _mapper,
        [FromServices] ICustomerMailEvent _mailEvent,
        [FromBody] CustomerCreateRequest request)
    {
        await new RegisterCustomer(_repository, _mailEvent, _mapper)
            .Execute(CustomerCreateDTO.ExtractProperties(request));

        return Created("", null);
    }

    [HttpPatch]
    [NoContent, NotFound, BadRequest, Unauthorized, Forbidden]
    public async Task<ActionResult> Update(
        [FromServices] IMapper _mapper,
        [FromBody] CustomerUpdateRequest request)
    {
        var customer = new CustomerIdentity(User);

        await new UpdateCustomer(_repository, _mapper)
            .Execute(CustomerUpdateDTO.ExtractProperties(request, customer.Id));

        return NoContent();
    }

    [HttpDelete]
    [NoContent, NotFound, Unauthorized, Forbidden]
    public async Task<ActionResult> Remove()
    {
        var customer = new CustomerIdentity(User);

        await new RemoveCustomer(_repository)
            .Execute(new() { Id = customer.Id });

        return NoContent();
    }
}