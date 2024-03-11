using System.Net;
using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using TestSetup.Fixtures;
using TestSetup.Shared;

namespace TestE2E.Endpoint;

public sealed class RegisterCustomerTest : SharedCustomerTest
{
    readonly CreateCustomerRequest Payload;

    public RegisterCustomerTest()
    {
        Payload = Mock.CreateRequest;
    }

    [Fact]
    public async void Should_Register_Customer()
    {
        using var app = new ServerFixtureE2E();

        var response = await app.Client.SendAsync(
            _requestFixture
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Post));

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_UniqueEmailConstraint_Response()
    {
        using var app = new ServerFixtureE2E();

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