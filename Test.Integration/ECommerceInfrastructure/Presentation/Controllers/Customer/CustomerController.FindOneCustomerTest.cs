using System.Net;
using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceDomain.DTOs;
using ECommerceInfrastructure.Presentation.Resources;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Test.Setup.Fixtures;
using Test.Setup.Mocks;

namespace Test.Integration.ECommerceInfrastructure.Presentation.Controllers;

public class CustomerControllerFindOneCustomerTest
{
    readonly ICustomerRepository _repositoryMock = Substitute.For<ICustomerRepository>();

    readonly RequestFixture _requestFixture = new("/api/v1/customers");

    readonly ResponseFixture _responseFixture = new();

    private void CreateMock()
    {
        CustomerDTO expectedInput = new() { Id = CustomerMocks.Customer.Id };

        _repositoryMock
            .FindOne(Arg.Is(expectedInput))
            .Returns(CustomerMocks.Customer);
    }

    [Fact]
    public async void Should_Return_One_CustomerResource()
    {
        CreateMock();

        using var app = new ServerFixture(x => { x.AddSingleton(_repositoryMock); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader()
            .CreateRequest(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerResource?>(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equivalent(CustomerMocks.Resource, responseContent);
    }


    [Fact]
    public async void Should_Return_NotFound_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repositoryMock); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .FakeAuthorizationHeader()
            .CreateRequest(HttpMethod.Get)
        );

        var responseContent = await _responseFixture
            .Deserialize<CustomerNotFoundException?>(response);

        Assert.Equal(HttpStatusCode.NotFound, response?.StatusCode);
        Assert.Equal(nameof(CustomerNotFoundException), responseContent?.Value.Error);
    }

    [Fact]
    public async void Should_Return_Unauthorized_Response()
    {
        using var app = new ServerFixture(x => { x.AddSingleton(_repositoryMock); });

        var response = await app.Client.SendAsync(
            _requestFixture
            .CreateRequest(HttpMethod.Get)
        );

        Assert.Equal(HttpStatusCode.Unauthorized, response?.StatusCode);
    }
}