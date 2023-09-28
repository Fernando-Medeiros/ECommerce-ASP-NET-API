using ECommerceApplication.Contracts;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Fixtures;
using Test.Setup.Mocks;

namespace Test.Setup.Shared;

public abstract class SharedCustomerTest
{
    public readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();

    public readonly RequestFixture _requestFixture = new("/api/v1/customers");

    public readonly ResponseFixture _responseFixture = new();

    public readonly CustomerMocks Mock = new();

    public void MakeRepositoryStub(CustomerDTO input, CustomerDTO? output)
    {
        _repository.FindOne(Arg.Is(input)).Returns(output);
    }
}
