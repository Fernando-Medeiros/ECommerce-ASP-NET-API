using ECommerceApplication.Request;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceTestSetup.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TestSetup.Fixtures;

namespace ECommerceTestIntegration.Endpoint;

public sealed class RegisterCustomerTest : SharedCustomerTest
{
    readonly RegisterCustomerRequest Payload;

    public RegisterCustomerTest()
    {
        Payload = Mock.CreateRequest;
    }

    [Fact]
    public async void Should_Register_Customer()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Email = Payload.Email },
            output: null);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Post));

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }


    [Fact]
    public async void Should_Return_BadRequest_Response()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Email = Payload.Email },
            output: Mock.CustomerDTO);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

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