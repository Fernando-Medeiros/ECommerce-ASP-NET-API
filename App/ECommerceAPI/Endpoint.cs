using ECommerceAPI.Resource;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase;
using ECommerceInfrastructure.Auth.Identities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceAPI;

internal static class Endpoint
{
    public static void Configure(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/customers", async (
            [FromServices] FindOneCustomer useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            var customerDto = await useCase.Execute(new(Id: customer.Id));
            return Results.Ok(new CustomerResource(customerDto));
        })
            .RequireAuthorization()
            .WithSummary("Find")
            .WithOpenApi()
            .Produces(200, typeof(CustomerResource));

        app.MapPost("/api/v1/customers", async (
            [FromServices] RegisterCustomer useCase,
            [FromBody] CreateCustomerRequest request) =>
        {
            await useCase.Execute(request);
            return Results.Created();
        })
            .AllowAnonymous()
            .WithSummary("Register")
            .WithOpenApi()
            .Produces(201);

        app.MapPatch("/api/v1/customers", async (
            [FromServices] UpdateCustomerNameAndEmail useCase,
            [FromBody] UpdateCustomerRequest request,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            request.Id = customer.Id;
            await useCase.Execute(request);
            return Results.NoContent();
        })
            .RequireAuthorization()
            .WithSummary("Update")
            .WithOpenApi()
            .Produces(204);

        app.MapDelete("/api/v1/customers", async (
            [FromServices] RemoveCustomer useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute(new(Id: customer.Id));
            return Results.NoContent();
        })
            .RequireAuthorization()
            .WithSummary("Remove")
            .WithOpenApi()
            .Produces(204);
    }
}
