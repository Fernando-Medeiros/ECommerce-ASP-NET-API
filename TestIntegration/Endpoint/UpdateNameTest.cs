using System.Net;
using ECommerceCommon.Exceptions;
using ECommerceApplication.Request;
using ECommerceDomain.DTO;
using Microsoft.Extensions.DependencyInjection;
using TestSetup.Fixtures;
using ECommerceTestSetup.Shared;

namespace TestIntegration.Endpoint;

public sealed class UpdateNameTest : SharedCustomerTest
{
    readonly NameRequest Payload;
    readonly CustomerDTO Query;

    public UpdateNameTest()
    {
        Payload = Mock.UpdateRequest;
        Query = new() { Id = Mock.UniqueId };
    }

    [Fact]
    public async void Should_Update_NameOrEmail()
    {
        MakeRepositoryStub(input: Query, output: Mock.CustomerDTO);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .AuthorizationHeader(Mock.CustomerDTO)
            .JsonContent(Payload)
            .RequestMessage(HttpMethod.Patch));

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async void Should_Return_Unauthorized_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .RequestMessage(HttpMethod.Patch));

        Assert.Equal(HttpStatusCode.Unauthorized, response?.StatusCode);
    }

    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        MakeRepositoryStub(input: Query, output: null);

        using var app = new ServerFixture(x => { x.AddSingleton(_repository); });

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