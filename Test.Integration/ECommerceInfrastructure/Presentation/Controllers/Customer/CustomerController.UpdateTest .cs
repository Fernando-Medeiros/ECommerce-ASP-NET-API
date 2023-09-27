using System.Net;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using ECommerceDomain.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceInfrastructure.Presentation.Controllers;

public sealed class CustomerControllerUpdateTest : SharedCustomerTest
{
    readonly UpdateCustomerRequest Payload = UpdateRequest;

    [Fact]
    public async void Should_Update_NameOrEmail()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Payload.Id },
            output: Customer);
        MakeRepositoryStub(
            input: new CustomerDTO() { Email = Payload.Email },
            output: null);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader()
            .CreateJsonContent(Payload)
            .CreateRequest(HttpMethod.Patch));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_Unauthorized_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .CreateRequest(HttpMethod.Patch));

        Assert.Equal(HttpStatusCode.Unauthorized, response?.StatusCode);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Payload.Id },
            output: null);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader()
            .CreateJsonContent(Payload)
            .CreateRequest(HttpMethod.Patch));

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}