using ECommerceApplication.Contracts;
using ECommerceApplication.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using NSubstitute;
using Test.Setup.Mocks;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public class FindOneCustomerTest
{
    readonly ICustomerRepository _repository = Substitute.For<ICustomerRepository>();

    readonly CustomerDTO CaseInput = new() { Id = CustomerMocks.Customer.Id };

    private void CreateStub(CustomerDTO input, CustomerDTO? output)
    {
        _repository.FindOne(Arg.Is(input)).Returns(output);
    }

    [Fact]
    public async void Should_Return_One_Customer()
    {
        CreateStub(
            input: CaseInput,
            output: CustomerMocks.Customer);

        var useCase = new FindOneCustomer(_repository);

        var result = await useCase.Execute(CaseInput);

        Assert.Equivalent(CustomerMocks.Customer, result);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var useCase = new FindOneCustomer(_repository);

        Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            CreateStub(
                input: CaseInput,
                output: null);

            _ = await useCase.Execute(CaseInput);
        });
    }
}
