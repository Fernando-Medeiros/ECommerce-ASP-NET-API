using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceInfrastructure.Authentication.Identities;
using ECommerceInfrastructure.Configuration.ApiResponse;
using ECommerceInfrastructure.Presentation.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInfrastructure.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/customers")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    [Authorize]
    [NotFound, Unauthorized, Forbidden]
    [Success(typeof(CustomerResource))]
    public async Task<ActionResult> FindOne(
        [FromServices] FindOneCustomer findOneCustomer)
    {
        var customer = new CustomerIdentity(User);

        var customerDto = await findOneCustomer
            .Execute(new() { Id = customer.Id });

        return Ok(new CustomerResource(customerDto));
    }

    [HttpPost]
    [Created, BadRequest]
    public async Task<ActionResult> Register(
        [FromServices] RegisterCustomer registerCustomer,
        [FromServices] IValidator<CreateCustomerRequest> validator,
        [FromBody] CreateCustomerRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        await registerCustomer.Execute(request);

        return Created("", null);
    }

    [HttpPatch]
    // [Authorize]
    [NoContent, NotFound, BadRequest, Unauthorized, Forbidden]
    public async Task<ActionResult> Update(
        [FromServices] UpdateCustomerNameAndEmail UpdateCustomerNameAndEmail,
        [FromServices] IValidator<UpdateCustomerRequest> validator,
        [FromBody] UpdateCustomerRequest request)
    {
        await validator.ValidateAndThrowAsync(request);

        var customer = new CustomerIdentity(User);

        request.Id(customer.Id);

        await UpdateCustomerNameAndEmail.Execute(request);

        return NoContent();
    }

    [HttpDelete]
    [Authorize]
    [NoContent, NotFound, Unauthorized, Forbidden]
    public async Task<ActionResult> Remove(
        [FromServices] RemoveCustomer removeCustomer)
    {
        var customer = new CustomerIdentity(User);

        await removeCustomer.Execute(new() { Id = customer.Id });

        return NoContent();
    }
}