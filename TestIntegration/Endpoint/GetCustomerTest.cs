using ECommerceAPI.Resource;
using ECommerceCommon.Exceptions;
using ECommerceDomain.DTO;
using ECommerceTestSetup.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using TestSetup.Fixtures;

namespace TestIntegration.Endpoint;

public sealed class GetCustomerTest : SharedCustomerTest
{
    [Fact]
    public async void Should_Return_CustomerResource()
    {
        MakeRepositoryStub(
            input: new CustomerDTO() { Id = Mock.UniqueId },
            output: Mock.CustomerDTO);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

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
    public async void Should_Return_Unauthorized_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .RequestMessage(HttpMethod.Get)
        );

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
            .AuthorizationHeader(Mock.CustomerDTO)
            .RequestMessage(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }
}