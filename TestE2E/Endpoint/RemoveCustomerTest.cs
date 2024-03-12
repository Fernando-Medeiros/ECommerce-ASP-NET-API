using System.Net;
using ECommerceCommon.Exceptions;
using ECommerceTestSetup.Shared;
using TestSetup.Fixtures;

namespace TestE2E.Endpoint;

public sealed class RemoveCustomerTest : SharedCustomerTest
{
    [Fact]
    public async void Should_Remove_Customer()
    {
        using var app = new ServerFixtureE2E();

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