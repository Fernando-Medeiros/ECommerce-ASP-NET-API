using System.Net;
using ECommerceApplication.Exceptions;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.E2E.ECommerceInfrastructure.Controllers;

public sealed class CustomerControllerRemoveTest : SharedCustomerTest
{
    [Fact]
    public async void Should_Remove_Customer()
    {
        using var app = new ServerFixtureE2E(table: ETable.customer);

        await app.InsertOneAsync(Mock.CustomerEntity);

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .RequestMessage(HttpMethod.Delete));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        using var app = new ServerFixture();

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .RequestMessage(HttpMethod.Delete));

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}