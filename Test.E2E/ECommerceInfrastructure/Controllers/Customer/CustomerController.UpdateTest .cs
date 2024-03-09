using System.Net;
using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.E2E.ECommerceInfrastructure.Controllers;

public sealed class CustomerControllerUpdateTest : SharedCustomerTest
{
    readonly UpdateCustomerRequest Payload;

    public CustomerControllerUpdateTest()
    {
        Payload = Mock.UpdateRequest;
    }

    [Fact]
    public async void Should_Update_NameOrEmail()
    {
        using var app = new ServerFixtureE2E();

        await app.InsertOneAsync(Mock.CustomerEntity);

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Patch));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        using var app = new ServerFixture();

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Patch));

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}