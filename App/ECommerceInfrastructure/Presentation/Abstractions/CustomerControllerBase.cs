using ECommerceApplication.Requests;
using ECommerceApplication.UseCases.Customer;
using ECommerceInfrastructure.Configuration.ProducesResponse;
using ECommerceInfrastructure.Presentation.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerceInfrastructure.Presentation.Abstractions;

[SwaggerTag("Register, Find, Update and Remove Customers")]
public abstract class CustomerControllerBase : ControllerBase
{
    [SwaggerOperation("Find Owner Customer", "Requires owner authentication")]
    [NotFound, Unauthorized, Forbidden, Success(typeof(CustomerResource))]
    public abstract Task<ActionResult> FindOne(
        [FromServices] FindOneCustomer useCase);


    [SwaggerOperation("Register a Customer")]
    [Created, BadRequest]
    public abstract Task<ActionResult> Register(
        [FromServices] RegisterCustomer useCase,
        [FromBody] CreateCustomerRequest request);


    [SwaggerOperation("Update Name or Email", "Requires owner authentication")]
    [NoContent, NotFound, BadRequest, Unauthorized, Forbidden]
    public abstract Task<ActionResult> Update(
        [FromServices] UpdateCustomerNameAndEmail useCase,
        [FromBody] UpdateCustomerRequest request
    );


    [SwaggerOperation("Remove a Customer", "Requires owner authentication")]
    [NoContent, NotFound, Unauthorized, Forbidden]
    public abstract Task<ActionResult> Remove(
        [FromServices] RemoveCustomer useCase
    );
}