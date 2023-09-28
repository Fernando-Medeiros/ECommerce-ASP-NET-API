using System.Net;
using ECommerceApplication.Exceptions;
using ECommerceApplication.Requests;
using Test.Setup.Fixtures;
using Test.Setup.Shared;

namespace Test.E2E.ECommerceInfrastructure.Controllers;

public sealed class CustomerControllerRegisterTest : SharedCustomerTest
{
    readonly CreateCustomerRequest Payload;

    public CustomerControllerRegisterTest()
    {
        Payload = Mock.CreateRequest;
    }

    [Fact]
    public async void Should_Register_Customer()
    {
        using var app = new ServerFixtureE2E(table: ETable.customer);

        var response = await app.Client.SendAsync(
            _requestFixture
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Post));

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_UniqueEmailConstraint_Response()
    {
        using var app = new ServerFixtureE2E(table: ETable.customer);

        await app.InsertOneAsync(Mock.CustomerEntity);

        var response = await app.Client.SendAsync(
            _requestFixture
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Post));

        var responseContent = await _responseFixture
            .Deserialize<UniqueEmailConstraintException?>(response);

        Assert.Equal(HttpStatusCode.BadRequest, response?.StatusCode);
        Assert.Equal(nameof(UniqueEmailConstraintException), responseContent?.Value.Error);
    }
}