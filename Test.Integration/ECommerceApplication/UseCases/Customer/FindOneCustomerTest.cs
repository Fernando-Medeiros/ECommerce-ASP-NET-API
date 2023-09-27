using ECommerceApplication.Exceptions;
using ECommerceApplication.UseCases.Customer;
using ECommerceDomain.DTOs;
using Test.Setup.Shared;

namespace Test.Integration.ECommerceApplication.UseCases.Customer;

public sealed class FindOneCustomerTest : SharedCustomerTest
{
    readonly CustomerDTO CaseInput = new() { Id = Customer.Id };

    [Fact]
    public async void Should_Return_One_Customer()
    {
        MakeRepositoryStub(
            input: CaseInput,
            output: Customer);

        var useCase = new FindOneCustomer(_repository);

        var result = await useCase.Execute(CaseInput);

        Assert.Equivalent(Customer, result);
    }

    [Fact]
    public void Should_Throw_Exception()
    {
        var useCase = new FindOneCustomer(_repository);

        Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            MakeRepositoryStub(
                input: CaseInput,
                output: null);

            _ = await useCase.Execute(CaseInput);
        });
    }
}
