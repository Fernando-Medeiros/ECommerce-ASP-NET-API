using ECommerceAPI.Resource;
using ECommerceApplication.Request;
using ECommerceApplication.UseCase.AuthCases;
using ECommerceApplication.UseCase.CustomerCases;
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
        app.MapPost("/api/v1/auth/token", async (
            [FromBody] SignInRequest request,
            GetAccessToken useCase) =>
        {
            var tokenDto = await useCase.Execute(request);
            return Results.Ok(new TokenResource(tokenDto));
        })
            .WithTags("Auth")
            .WithOpenApi()
            .Produces(201, typeof(TokenResource));

        app.MapPost("/api/v1/auth/email", async (
            CheckEmail useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user, [ETokenScope.AuthenticateEmail]);
            var tokenDto = await useCase.Execute(new() { Id = customer.Id });
            return Results.Ok(new TokenResource(tokenDto));
        })
            .RequireAuthorization()
            .WithTags("Auth")
            .WithOpenApi()
            .Produces(201, typeof(TokenResource));
        #endregion

        #region Password
        app.MapPost("/api/v1/password/recover", async (
            [FromBody] EmailRequest request,
            RecoverPassword useCase) =>
        {
            await useCase.Execute(request);
            return Results.Ok();
        })
            .WithTags("Password")
            .WithOpenApi()
            .Produces(200);

        app.MapPatch("/api/v1/password/reset", async (
            [FromBody] PasswordRequest request,
            UpdatePassword useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user, [ETokenScope.RecoverPassword]);
            await useCase.Execute((new() { Id = customer.Id }, request));
            return Results.Ok();
        })
            .RequireAuthorization()
            .WithTags("Password")
            .WithOpenApi()
            .Produces(200);

        app.MapPatch("/api/v1/password", async (
            [FromBody] PasswordRequest request,
            UpdatePassword useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute((new() { Id = customer.Id }, request));
            return Results.Ok();
        })
            .RequireAuthorization()
            .WithTags("Password")
            .WithOpenApi()
            .Produces(200);
        #endregion

        #region Customer
        app.MapGet("/api/v1/customer", async (
            GetCustomer useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            var customerDto = await useCase.Execute(new() { Id = customer.Id });
            return Results.Ok(new CustomerResource(customerDto));
        })
            .RequireAuthorization()
            .WithTags("Customer")
            .WithOpenApi()
            .Produces(200, typeof(CustomerResource));

        app.MapPost("/api/v1/customer", async (
            [FromBody] CustomerRequest request,
            RegisterCustomer useCase) =>
        {
            await useCase.Execute(request);
            return Results.Created();
        })
            .WithTags("Customer")
            .WithOpenApi()
            .Produces(201);

        app.MapPatch("/api/v1/customer", async (
            [FromBody] NameRequest request,
            UpdateCustomerName useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute((new() { Id = customer.Id }, request));
            return Results.NoContent();
        })
            .RequireAuthorization()
            .WithTags("Customer")
            .WithOpenApi()
            .Produces(204);

        app.MapDelete("/api/v1/customer", async (
            RemoveCustomer useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute(new() { Id = customer.Id });
            return Results.NoContent();
        })
            .RequireAuthorization()
            .WithTags("Customer")
            .WithOpenApi()
            .Produces(204);
        #endregion

        #region Address
        app.MapGet("/api/v1/address/{id:required}", async (
            FindCustomerAddress useCase,
            ClaimsPrincipal user,
            string? id) =>
        {
            var customer = new CustomerIdentity(user);
            var address = await useCase.Execute(new() { Id = id });
            return Results.Ok(new AddressResource(address));
        })
            .RequireAuthorization()
            .WithTags("Customer Address")
            .WithOpenApi()
            .Produces(200, typeof(AddressResource));

        app.MapGet("/api/v1/address", async (
            GetCustomerAddresses useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            var addresses = await useCase.Execute(new() { Id = customer.Id });
            return Results.Ok(AddressResource.ToArray(addresses));
        })
            .RequireAuthorization()
            .WithTags("Customer Address")
            .WithOpenApi()
            .Produces(200, typeof(IEnumerable<AddressResource>));

        app.MapPost("/api/v1/address", async (
            [FromBody] AddressRequest request,
            RegisterCustomerAddress useCase,
            ClaimsPrincipal user) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute((new() { Id = customer.Id }, request));
            return Results.Created();
        })
            .RequireAuthorization()
            .WithTags("Customer Address")
            .WithOpenApi()
            .Produces(201);

        app.MapPatch("/api/v1/address/{id:required}", async (
            [FromBody] AddressRequest request,
            UpdateCustomerAddress useCase,
            ClaimsPrincipal user,
            string? id) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute((new() { Id = id }, request));
            return Results.NoContent();
        })
            .RequireAuthorization()
            .WithTags("Customer Address")
            .WithOpenApi()
            .Produces(204);

        app.MapDelete("/api/v1/address/{id:required}", async (
            RemoveCustomerAddress useCase,
            ClaimsPrincipal user,
            string? id) =>
        {
            var customer = new CustomerIdentity(user);
            await useCase.Execute(new() { Id = id });
            return Results.NoContent();
        })
            .RequireAuthorization()
            .WithTags("Customer Address")
            .WithOpenApi()
            .Produces(204);
        #endregion
    }
}
