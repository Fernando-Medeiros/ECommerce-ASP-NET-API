using AutoMapper;
using ECommerce.Events.Mail;
using ECommerce.Identities;
using ECommerce.Setup.ApiProducesResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Modules.Customer;

[ApiController]
[Route("api/v1/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerController(
        ICustomerRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
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

    [HttpPost]
    [Created, BadRequest]
    public async Task<ActionResult> Register(
        [FromServices] ICustomerMailEvent _mailEvent,
        [FromBody] CustomerCreateRequest request)
    {
        var requestMapped = _mapper.Map<CustomerDTO>(request);

        await new RegisterCustomer(_repository, _mailEvent, _mapper)
            .Execute(requestMapped);

        return Created("", null);
    }

    [HttpPatch]
    [Authorize]
    [NoContent, NotFound, BadRequest, Unauthorized, Forbidden]
    public async Task<ActionResult> Update(
        [FromBody] CustomerUpdateRequest request)
    {
        var customer = new CustomerIdentity(User);

        var requestMapped = _mapper.Map<CustomerDTO>(request);

        requestMapped.Id = customer.Id;

        await new UpdateCustomer(_repository, _mapper)
            .Execute(requestMapped);

        return NoContent();
    }

    [HttpDelete]
    [Authorize]
    [NoContent, NotFound, Unauthorized, Forbidden]
    public async Task<ActionResult> Remove()
    {
        var customer = new CustomerIdentity(User);

        await new RemoveCustomer(_repository)
            .Execute(new() { Id = customer.Id });

        return NoContent();
    }
}