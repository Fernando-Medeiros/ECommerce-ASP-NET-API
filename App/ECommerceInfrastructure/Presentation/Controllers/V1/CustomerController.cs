using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceInfrastructure.Authentication.Identities;
using ECommerceInfrastructure.Presentation.Abstractions;
using ECommerceInfrastructure.Presentation.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInfrastructure.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/customers")]
public sealed class CustomerController : CustomerControllerBase
{
    [HttpGet, Authorize]
    public override async Task<ActionResult> FindOne(
        [FromServices] FindOneCustomer useCase)
    {
        var customer = new CustomerIdentity(User);

        var customerDto = await useCase.Execute(new(Id: customer.Id));

        return Ok(new CustomerResource(customerDto));
    }

    [HttpPost]
    public override async Task<ActionResult> Register(
        [FromServices] RegisterCustomer useCase,
        [FromBody] CreateCustomerRequest request)
    {
        await useCase.Execute(request);

        return Created("", null);
    }

    [HttpPatch, Authorize]
    public override async Task<ActionResult> Update(
        [FromServices] UpdateCustomerNameAndEmail useCase,
        [FromBody] UpdateCustomerRequest request)
    {
        var customer = new CustomerIdentity(User);

        request.Id = customer.Id;

        await useCase.Execute(request);

        return NoContent();
    }

    [HttpDelete, Authorize]
    public override async Task<ActionResult> Remove(
        [FromServices] RemoveCustomer useCase)
    {
        var customer = new CustomerIdentity(User);

        await useCase.Execute(new(Id: customer.Id));

        return NoContent();
    }
}
