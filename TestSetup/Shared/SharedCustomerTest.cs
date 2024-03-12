using ECommerceApplication.Contract;
using ECommerceDomain.DTO;
using ECommerceTestSetup.Fixtures;
using ECommerceTestSetup.Mocks;
using NSubstitute;
using TestSetup.Fixtures;

namespace ECommerceTestSetup.Shared;

public abstract class SharedCustomerTest
{
    public readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();

    public readonly RequestFixture _requestFixture = new("/api/v1/customers");

    public readonly ResponseFixture _responseFixture = new();

    public readonly CustomerMocks Mock = new();

    public void MakeRepositoryStub(CustomerDTO input, CustomerDTO? output)
    {
        _repository.Find(Arg.Is(input)).Returns(output);
    }
}
