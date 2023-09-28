using System.Net;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceInfrastructure.Presentation.Controllers;

public sealed class CustomerControllerRemoveTest : SharedCustomerTest
{
    [Fact]
    public async void Should_Remove_Customer()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Mock.UniqueId },
            output: Mock.CustomerDTO);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader(Mock.CustomerDTO)
            .CreateRequest(HttpMethod.Delete));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_Unauthorized_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .CreateRequest(HttpMethod.Delete));

        Assert.Equal(HttpStatusCode.Unauthorized, response?.StatusCode);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Mock.UniqueId },
            output: null);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader(Mock.CustomerDTO)
            .CreateRequest(HttpMethod.Delete));

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}