using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Mocks;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public class FindOneCustomerTest
{
    readonly ICustomerRepository _repositoryMock = Substitute.For<ICustomerRepository>();

    readonly CustomerDTO expectedInput = new() { Id = CustomerMocks.Customer.Id };

    private void CreateMock()
    {
        _repositoryMock
            .FindOne(Arg.Is(expectedInput))
            .Returns(CustomerMocks.Customer);
    }

    [Fact]
    public async void Should_Return_One_Customer()
    {
        CreateMock();

        var useCase = new FindOneCustomer(_repositoryMock);

        var result = await useCase.Execute(expectedInput);

        Assert.Equivalent(CustomerMocks.Customer, result);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var useCase = new FindOneCustomer(_repositoryMock);

        Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            _ = await useCase.Execute(expectedInput);
        });
    }
}
