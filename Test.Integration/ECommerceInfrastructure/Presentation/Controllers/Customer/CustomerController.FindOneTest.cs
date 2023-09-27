using System.Net;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Presentation.Resources;
using Microsoft.Extensions.DependencyInjection;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceInfrastructure.Presentation.Controllers;

public sealed class CustomerControllerFindOneTest : SharedCustomerTest
{
    [Fact]
    public async void Should_Return_CustomerResource()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Customer.Id },
            output: Customer);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader()
            .CreateRequest(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerResource?>(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equivalent(Resource, responseContent);
    }

    [Fact]
    public async void Should_Return_Unauthorized_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .CreateRequest(HttpMethod.Get)
        );

        Assert.Equal(HttpStatusCode.Unauthorized, response?.StatusCode);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Customer.Id },
            output: null);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader()
            .CreateRequest(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}