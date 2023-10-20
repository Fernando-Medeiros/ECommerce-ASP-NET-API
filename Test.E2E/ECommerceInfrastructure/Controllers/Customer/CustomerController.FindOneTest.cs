using System.Net;
using ECommerceCommon.Exceptions;
using ECommerceInfrastructure.Presentation.Resources;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.E2E.ECommerceInfrastructure.Controllers;

public sealed class CustomerControllerFindOneTest : SharedCustomerTest
{
    [Fact]
    public async void Should_Return_CustomerResource()
    {
        using var app = new ServerFixtureE2E();

        await app.InsertOneAsync(Mock.CustomerEntity);

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .RequestMessage(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerResource?>(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equivalent(Mock.CustomerResource, responseContent);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        using var app = new ServerFixture();

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .RequestMessage(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}