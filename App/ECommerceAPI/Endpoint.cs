using ECommerceAPI.Resource;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase;
using ECommerceDomain.Enums;
using ECommerceInfrastructure.Auth.Identities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceAPI;

internal static class Endpoint
{
    public static void Configure(IEndpointRouteBuilder app)
    {
        #region Authentication
        app.MapPost("/api/v1/access-token", async (
            [FromServices] RegisterToken useCase,
            [FromBody] SignInRequest request) =>
        {
            var tokenDto = await useCase.Execute(request);
            return Results.Ok(new TokenResource(tokenDto));
        })
            .WithTags("Auth")
            .WithOpenApi()
            .Produces(201, typeof(TokenResource));

        app.MapPost("/api/v1/check-email", async (
            [FromServices] AuthenticateCustomer useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user, [ETokenScope.AuthenticateEmail]);
            var tokenDto = await useCase.Execute(customer.Id);
            return Results.Ok(new TokenResource(tokenDto));
        })
            .RequireAuthorization()
            .WithTags("Auth")
            .WithOpenApi()
            .Produces(201, typeof(TokenResource));
        #endregion

        #region Password
        app.MapPost("/api/v1/recover-password", async (
          [FromServices] RecoverPassword useCase,
          [FromBody] EmailRequest request) =>
        {
            await useCase.Execute(request);
            return Results.Ok();
        })
          .WithTags("Auth")
          .WithOpenApi()
          .Produces(200);

        app.MapPatch("/api/v1/reset-password", async (
            [FromServices] UpdatePassword useCase,
            [FromBody] PasswordRequest request,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user, [ETokenScope.RecoverPassword]);
            await useCase.Execute((customer.Id, request));
            return Results.Ok();
        })
            .RequireAuthorization()
            .WithTags("Auth")
            .WithOpenApi()
            .Produces(200);

        app.MapPatch("/api/v1/update-password", async (
            [FromServices] UpdatePassword useCase,
            [FromBody] PasswordRequest request,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute((customer.Id, request));
            return Results.Ok();
        })
            .RequireAuthorization()
            .WithTags("Auth")
            .WithOpenApi()
            .Produces(200);
        #endregion

        #region Customer
        app.MapGet("/api/v1/customers", async (
            [FromServices] FindOneCustomer useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            var customerDto = await useCase.Execute(new(Id: customer.Id));
            return Results.Ok(new CustomerResource(customerDto));
        })
            .RequireAuthorization()
            .WithTags("Customer")
            .WithOpenApi()
            .Produces(200, typeof(CustomerResource));

        app.MapPost("/api/v1/customers", async (
            [FromServices] RegisterCustomer useCase,
            [FromBody] CustomerRequest request) =>
        {
            await useCase.Execute(request);
            return Results.Created();
        })
            .WithTags("Customer")
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
            .WithTags("Customer")
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
            .WithTags("Customer")
            .WithOpenApi()
            .Produces(204);
        #endregion
    }
}
